using Aplicacao.Imobiliaria.DTOs;

namespace Aplicacao.Imobiliaria.Interfaces;

public interface ICaracteristicaService {
    Task<IEnumerable<CaracteristicaDTO>> ObterTodas();
}