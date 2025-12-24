using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Repositorio.Interfaces;
using Util.Enums;

namespace Aplicacao.Imobiliaria.Servicos;
public class PesquisaImovelService : IPesquisaImovelService {

    private IPesquisaImovelRepository ImovelRepository;

    public PesquisaImovelService(IPesquisaImovelRepository ImovelRepository) {
        this.ImovelRepository = ImovelRepository;
    }

    public async Task<ImovelPesquisaDTO> ObterPorId(int? id) {
        if (id == null) {
            throw new ArgumentNullException(nameof(id), "Id cannot be null.");
        }

        var imovel = await ImovelRepository.ObterPorId(id);

        if (imovel == null) {
            throw new KeyNotFoundException($"Imovel with Id {id} not found.");
        }

        var caracteristicas = imovel.ImoveisCaracteristicas
            .Select(ic => new ImovelCaracteristicaDTO(Acao.NaoDefinido, ic.Id, ic.CaracteristicaId, ic.Caracteristica.Descricao))
            .ToArray();

        return new ImovelPesquisaDTO(
            imovel.Id,
            imovel.TipoImovel,
            imovel.Area,
            imovel.Quartos,
            imovel.VagasGaragem,
            imovel.Valor
        );
    }

    public async Task<ImovelPesquisaPaginacaoDTO> Pesquisar(int pagina, int? quartos, decimal? valorInicial, decimal? valorFinal) {
        var paginacaoResult = await ImovelRepository.Obter(pagina, quartos, valorInicial, valorFinal);

        var imoveis = paginacaoResult.Itens.Select(i => new ImovelPesquisaDTO(
            i.Id,
            i.TipoImovel,
            i.Area,
            i.Quartos,
            i.VagasGaragem,
            i.Valor
        ));

        return new ImovelPesquisaPaginacaoDTO(paginacaoResult.RegistrosPorPagina,  paginacaoResult.TotalPaginas, imoveis.ToArray());
    }
}