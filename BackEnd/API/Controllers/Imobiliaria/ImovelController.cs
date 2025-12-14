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
        var imovel = await ImovelService.Criar(ImovelDTO);
        return imovel.Id;
    }

    [HttpPut("{id}")]
    public async Task<bool> Atualizar(int id, [FromBody] ImovelDTO ImovelDTO) {
        await ImovelService.Atualizar(id, ImovelDTO);
        return true;
    }

    [HttpGet]
    public async Task<ImovelDTO[]> ObterTodos() {
        Thread.Sleep(1000);
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