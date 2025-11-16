using Domain;

namespace Repositorio.Interfaces;

public interface IUnidadeFederacaoRepository {
    Task<IEnumerable<UnidadeFederacao>> ObterUnidadesFederacao();
    Task<UnidadeFederacao> ObterPorId(int? id);
    Task<int> Criar(UnidadeFederacao unidadeFederacao);
    Task Atualizar(UnidadeFederacao unidadeFederacao);
    Task Excluir(UnidadeFederacao unidadeFederacao);
}