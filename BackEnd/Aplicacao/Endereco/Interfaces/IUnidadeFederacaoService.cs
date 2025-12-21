using Aplicacao.DTOs.Imovel;
using Aplicacao.Endereco.DTOs;

namespace Aplicacao.Endereco.Interfaces;

public interface IUnidadeFederacaoService {
    Task<IEnumerable<UnidadeFederacaoDTO>> ObterUnidadesFederacao();
    Task<UnidadeFederacaoDTO> ObterPorId(int? id);
    Task<int> Criar(UnidadeFederacaoDTO unidadeFederacaoDTO);
    Task Excluir(int? id);
    Task ExcluirTudo();
    Task Atualizar(int id, UnidadeFederacaoDTO unidadeFederacaoDTO);
    Task ObterUfsDoIbge();
}