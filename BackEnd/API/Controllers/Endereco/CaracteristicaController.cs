using Aplicacao.Endereco.DTOs;
using Aplicacao.Endereco.Interfaces;
using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Endereco;

[ApiController]
[Route("Caracteristica")]
public class CaracteristicaController : ControllerBase {

    private ICaracteristicaService CaracteristicaService;

    public CaracteristicaController(ICaracteristicaService CaracteristicaService) {
        this.CaracteristicaService = CaracteristicaService;
    }

    [HttpGet]
    public async Task<CaracteristicaDTO[]> ObterTodas() {
        var unidades = await CaracteristicaService.ObterTodas();
        return unidades.ToArray();
    }
}