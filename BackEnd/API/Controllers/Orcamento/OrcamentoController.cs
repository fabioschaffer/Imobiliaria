using Aplicacao.Endereco.DTOs;
using Aplicacao.Endereco.Interfaces;
using Aplicacao.Endereco.Servicos;
using Aplicacao.Interfaces.ImovelNS;
using Aplicacao.Interfaces.T_Orcamento;
using Aplicacao.Servicos.T_Orcamento;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Endereco;

[ApiController]
[Route("Orcamento")]
public class OrcamentoController : ControllerBase {

    private IOrcamentoService OrcamentoService;

    public OrcamentoController(IOrcamentoService orcamentoService) {
        OrcamentoService = orcamentoService;
    }

    [HttpPost]
    public async Task Criar() {
        await OrcamentoService.Criar();
    }

    [HttpGet("{id}")]
    public async Task ObterPorId(int id)
    {
        await OrcamentoService.ObterPorId(id);
    }

    [HttpPost("processar")]
    public void Processar(int id)
    {
        OrcamentoService.Processar();
    }
}