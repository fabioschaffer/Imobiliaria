using Aplicacao.DTOs;
using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UnidadeFederacaoController : ControllerBase {

    private IUnidadeFederacaoService unidadeFederacaoService;

    public UnidadeFederacaoController(IUnidadeFederacaoService unidadeFederacaoService) {
        this.unidadeFederacaoService = unidadeFederacaoService;
    }

    [HttpPost(Name = "Criar")]
    public async Task<int> Criar([FromBody] UnidadeFederacaoDTO unidadeFederacaoDTO) {

        var id = await unidadeFederacaoService.Criar(unidadeFederacaoDTO);

        return id;
    }
}