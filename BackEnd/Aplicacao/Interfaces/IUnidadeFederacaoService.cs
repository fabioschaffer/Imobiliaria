using Aplicacao.DTOs;

namespace Aplicacao.Interfaces;

public interface IUnidadeFederacaoService {
    Task<IEnumerable<UnidadeFederacaoDTO>> ObterUnidadesFederacao();
    Task<UnidadeFederacaoDTO> ObterPorId(int? id);
    Task<int> Criar(UnidadeFederacaoDTO unidadeFederacaoDTO);
    Task Atualizar(UnidadeFederacaoDTO unidadeFederacaoDTO);
    Task Excluir(int? id);
}