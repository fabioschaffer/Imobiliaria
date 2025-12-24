using Aplicacao.Endereco.DTOs;
using Aplicacao.Endereco.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Endereco;

[ApiController]
[Route("UnidadeFederacao")]
public class UnidadeFederacaoController : ControllerBase {

    private IUnidadeFederacaoService unidadeFederacaoService;

    public UnidadeFederacaoController(IUnidadeFederacaoService unidadeFederacaoService) {
        this.unidadeFederacaoService = unidadeFederacaoService;
    }

    [HttpPost]
    public async Task<int> Criar([FromBody] UnidadeFederacaoDTO unidadeFederacaoDTO) {

        var id = await unidadeFederacaoService.Criar(unidadeFederacaoDTO);
        return id;
    }

    [HttpPut("{id}")]
    public async Task<bool> Atualizar(int id, [FromBody] UnidadeFederacaoDTO unidadeFederacaoDTO) {
        await unidadeFederacaoService.Atualizar(id, unidadeFederacaoDTO);
        return true;
    }

    [HttpGet]
    public async Task<UnidadeFederacaoDTO[]> ObterTodas() {
        var unidades = await unidadeFederacaoService.ObterUnidadesFederacao();
        return unidades.ToArray();
    }

    [HttpGet("{id}")]
    public async Task<UnidadeFederacaoDTO> ObterPorId(int id) {
        var unidade = await unidadeFederacaoService.ObterPorId(id);
        return unidade;
    }

    [HttpDelete("{id}")]
    public async Task<bool> Excluir(int id) {
        await unidadeFederacaoService.Excluir(id);
        return true;
    }

    [HttpDelete("ExcluirTudo")]
    public async Task<IActionResult> ExcluirTudo()
    {
        await unidadeFederacaoService.ExcluirTudo();
        return new OkResult();
    }


    [HttpPost("ObterUfsDoIbge")]
    public async Task<IActionResult> ObterUfsDoIbge()
    {
        await unidadeFederacaoService.ObterUfsDoIbge();
        return new OkResult();
    }
}