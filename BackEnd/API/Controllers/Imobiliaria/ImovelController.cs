using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Imobiliaria;

[ApiController]
[Route("Imovel")]
public class ImovelController : ControllerBase {

    private IImovelService ImovelService;

    public ImovelController(IImovelService ImovelService) {
        this.ImovelService = ImovelService;
    }

    [HttpPost]
    public async Task<int> Criar([FromBody] ImovelDTO ImovelDTO) {
        var id = await ImovelService.Criar(ImovelDTO);
        return id;
    }

    [HttpPut("{id}")]
    public async Task<bool> Atualizar(int id, [FromBody] ImovelDTO ImovelDTO) {
        await ImovelService.Atualizar(id, ImovelDTO);
        return true;
    }

    [HttpGet]
    public async Task<ImovelDTO[]> ObterTodas() {
        var unidades = await ImovelService.ObterImoveis();
        return unidades.ToArray();
    }

    [HttpGet("{id}")]
    public async Task<ImovelDTO> ObterPorId(int id) {
        var unidade = await ImovelService.ObterPorId(id);
        return unidade;
    }

    [HttpDelete("{id}")]
    public async Task<bool> Excluir(int id) {
        await ImovelService.Excluir(id);
        return true;
    }
}