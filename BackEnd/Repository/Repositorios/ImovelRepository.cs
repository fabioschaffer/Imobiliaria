using Dominio.Entidades.Imobiliaria;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;

namespace Repositorio.Repositorios;
public class ImovelRepository : IImovelRepository {

    private AplicacaoDbContext contexto;

    public ImovelRepository(AplicacaoDbContext contexto) {
        this.contexto = contexto;
    }
    public async Task Criar(Imovel imovel) {
        contexto.Add(imovel);
        await contexto.SaveChangesAsync();
    }

    public async Task Atualizar(Imovel Imovel) {
        contexto.Imoveis.Update(Imovel);
        await contexto.SaveChangesAsync();
    }

    public async Task Excluir(Imovel Imovel) {
        contexto.Imoveis.Remove(Imovel);
        await contexto.SaveChangesAsync();
    }

    public async Task<Imovel> ObterPorId(int? id) {
        if (id == null) {
            throw new ArgumentNullException(nameof(id), "O ID não pode ser nulo.");
        }

        var Imovel = await contexto.Imoveis.FindAsync(id);

        if (Imovel == null) {
            throw new KeyNotFoundException($"Nenhuma Imovel encontrada com o ID {id}.");
        }

        return Imovel;
    }

    public async Task<IEnumerable<Imovel>> Obter() {
        return await contexto.Imoveis.ToListAsync();
    }
}