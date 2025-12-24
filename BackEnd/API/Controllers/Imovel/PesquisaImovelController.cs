using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Imovel;

[ApiController]
[Route("PesquisaImovel")]
public class PesquisaImovelController(IPesquisaImovelService service) : ControllerBase {

    [HttpGet("Pesquisar")]
    public async Task<ImovelPesquisaPaginacaoDTO> Pesquisar(int pagina, int? quartos, decimal? valorInicial, decimal? valorFinal) {
        var imoveis = await service.Pesquisar(pagina, quartos, valorInicial, valorFinal);
        return imoveis;
    }

    [HttpGet("{id}")]
    public async Task<ImovelPesquisaDTO> ObterPorId(int id) {
        var imovel = await service.ObterPorId(id);
        return imovel;
    }
}
