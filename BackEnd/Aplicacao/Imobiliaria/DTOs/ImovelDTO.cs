using Dominio.Enums;

namespace Aplicacao.Imobiliaria.DTOs;

public record ImovelDTO(
    int Id,
    TipoImovel TipoImovel,
    decimal Area,
    byte Quartos,
    byte VagasGaragem,
    decimal Valor,
    ImovelCaracteristicaDTO[] Caracteristicas
) {
    public ImovelCaracteristicaDTO[] Caracteristicas { get; init; } = Caracteristicas ?? [];
}

public record ImovelPaginacaoDTO(
    int Id,
    TipoImovel TipoImovel,
    decimal Area,
    byte Quartos,
    byte VagasGaragem,
    decimal Valor,
    ImovelCaracteristicaDTO[] Caracteristicas,
    int TotalLinhas
)
{
    public ImovelCaracteristicaDTO[] Caracteristicas { get; init; } = Caracteristicas ?? [];
}