using Aplicacao.DTOs.Imovel;
using Aplicacao.Endereco.DTOs;
using Aplicacao.Endereco.Interfaces;
using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Aplicacao.Interfaces.ImovelNS;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Imovel;

[ApiController]
[Route("imovel/tipo")]
public class TipoController : ControllerBase {

    private ITipoService TipoService;

    public TipoController(ITipoService TipoService) {
        this.TipoService = TipoService;
    }

    [HttpGet]
    public async Task<TipoDTO[]> ObterTodas() {
        var unidades = await TipoService.ObterTodos();
        return unidades.ToArray();
    }
}