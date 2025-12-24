using Dominio.Entidades.Imobiliaria;
using Microsoft.EntityFrameworkCore;
using Repositorio.Configuracoes;
using Repositorio.Contexto;
using Repositorio.Interfaces;

namespace Repositorio.Repositorios;
public class PesquisaImovelRepository : IPesquisaImovelRepository
{

    private AplicacaoDbContext contexto;

    public PesquisaImovelRepository(AplicacaoDbContext contexto)
    {
        this.contexto = contexto;
    }
    public async Task<Imovel> ObterPorId(int? id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), "O ID não pode ser nulo.");
        }

        var Imovel = await contexto.Imoveis
            .Include(i => i.ImoveisCaracteristicas)
            .ThenInclude(ic => ic.Caracteristica)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (Imovel == null)
        {
            throw new KeyNotFoundException($"Nenhuma Imovel encontrada com o ID {id}.");
        }

        return Imovel;
    }

    public async Task<PaginacaoResult<Imovel>> Obter(int pagina, int? quartos, decimal? valorInicial, decimal? valorFinal) {
        var query = contexto.Imoveis.AsQueryable();

        if (quartos.HasValue) {
            query = query.Where(i => i.Quartos == quartos.Value);
        }

        if (valorInicial.HasValue) {
            query = query.Where(i => i.Valor >= valorInicial.Value);
        }

        if (valorFinal.HasValue) {
            query = query.Where(i => i.Valor <= valorFinal.Value);
        }

        query = query.OrderBy(o => o.Id);

        var total = await query.CountAsync();

        var itens = await query
            .Skip((pagina - 1) * Paginacao.LinhasPorPaginaPesquisaImovel)
            .Take(Paginacao.LinhasPorPaginaPesquisaImovel)
            .ToListAsync();

        var resultado = new PaginacaoResult<Imovel> {
            RegistrosPorPagina = Paginacao.LinhasPorPaginaPesquisaImovel,
            TotalRegistros = total,
            Itens = itens
        };

        return resultado;
    }
}