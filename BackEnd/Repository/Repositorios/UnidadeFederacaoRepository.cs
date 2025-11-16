using Domain;
using Repositorio.Contexto;
using Repositorio.Interfaces;

namespace Repositorio.Repositorios;
public class UnidadeFederacaoRepository : IUnidadeFederacaoRepository {

    private AplicacaoDbContext contexto;

    public UnidadeFederacaoRepository(AplicacaoDbContext contexto) {
        this.contexto = contexto;
    }

    public Task Atualizar(UnidadeFederacao unidadeFederacao) => throw new NotImplementedException();
    public async Task<int> Criar(UnidadeFederacao unidadeFederacao) {

        contexto.Add(unidadeFederacao);
        await contexto.SaveChangesAsync();
        return unidadeFederacao.Id;
    }

    public Task Excluir(UnidadeFederacao unidadeFederacao) => throw new NotImplementedException();
    public Task<UnidadeFederacao> ObterPorId(int? id) => throw new NotImplementedException();
    public Task<IEnumerable<UnidadeFederacao>> ObterUnidadesFederacao() => throw new NotImplementedException();
}
