using Aplicacao.DTOs;
using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    public async Task Atualizar(int id, [FromBody] UnidadeFederacaoDTO unidadeFederacaoDTO) {
        await unidadeFederacaoService.Atualizar(id, unidadeFederacaoDTO);
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
    public async Task Excluir(int id) {
        await unidadeFederacaoService.Excluir(id);
    }

}