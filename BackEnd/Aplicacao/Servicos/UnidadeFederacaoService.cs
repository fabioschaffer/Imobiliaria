using Aplicacao.DTOs;
using Aplicacao.Interfaces;
using Domain;
using Repositorio.Interfaces;

namespace Aplicacao.Servicos;
public class UnidadeFederacaoService : IUnidadeFederacaoService {

    private IUnidadeFederacaoRepository unidadeFederacaoRepository;

    public UnidadeFederacaoService(IUnidadeFederacaoRepository unidadeFederacaoRepository) {
        this.unidadeFederacaoRepository = unidadeFederacaoRepository;
    }

    public async Task<int> Criar(UnidadeFederacaoDTO unidadeFederacaoDTO) {

        var unidadeFederacao = new UnidadeFederacao(unidadeFederacaoDTO.Nome);

        await unidadeFederacaoRepository.Criar(unidadeFederacao);

        return unidadeFederacao.Id;
    }

    public Task Atualizar(UnidadeFederacaoDTO unidadeFederacaoDTO) => throw new NotImplementedException();
    public Task Excluir(int? id) => throw new NotImplementedException();
    public Task<UnidadeFederacaoDTO> ObterPorId(int? id) => throw new NotImplementedException();
    public Task<IEnumerable<UnidadeFederacaoDTO>> ObterUnidadesFederacao() => throw new NotImplementedException();
}
