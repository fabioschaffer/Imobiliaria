using Dominio.Enums;

namespace Aplicacao.Imobiliaria.DTOs;

public record ImovelDTO(
    int Id,
    TipoImovel TipoImovel,
    decimal Area,
    byte Quartos,
    byte VagasGaragem,
    decimal Valor,
    ImovelCaracteristicaDTO[] ImovelCaracteristicas
) {
    public ImovelCaracteristicaDTO[] ImovelCaracteristicas { get; init; } = ImovelCaracteristicas ?? Array.Empty<ImovelCaracteristicaDTO>();
}