using Dominio.Entidades.EnderecoNS;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;

namespace Repositorio.Repositorios;
public class UnidadeFederacaoRepository : IUnidadeFederacaoRepository {

    private AplicacaoDbContext contexto;

    public UnidadeFederacaoRepository(AplicacaoDbContext contexto) {
        this.contexto = contexto;
    }
    public async Task<int> Criar(UnidadeFederacao unidadeFederacao) {
        contexto.Add(unidadeFederacao);
        await contexto.SaveChangesAsync();
        return unidadeFederacao.Id;
    }

    public async Task Atualizar(UnidadeFederacao unidadeFederacao) {
        contexto.UnidadesFederacao.Update(unidadeFederacao);
        await contexto.SaveChangesAsync();
    }

    public async Task Excluir(UnidadeFederacao unidadeFederacao) {
        contexto.UnidadesFederacao.Remove(unidadeFederacao);
        await contexto.SaveChangesAsync();
    }

    public async Task<UnidadeFederacao> ObterPorId(int? id) {
        if (id == null) {
            throw new ArgumentNullException(nameof(id), "O ID não pode ser nulo.");
        }

        var unidadeFederacao = await contexto.UnidadesFederacao.FindAsync(id);

        if (unidadeFederacao == null) {
            throw new KeyNotFoundException($"Nenhuma UnidadeFederacao encontrada com o ID {id}.");
        }

        return unidadeFederacao;
    }

    public async Task<IEnumerable<UnidadeFederacao>> ObterUnidadesFederacao() {
        return await contexto.UnidadesFederacao.ToListAsync();
    }
}