using Aplicacao.Endereco.DTOs;
using Aplicacao.Endereco.Interfaces;
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
}