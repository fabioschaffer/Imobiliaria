using Dominio.Enums;

namespace Aplicacao.Imobiliaria.DTOs;

public record ImovelPesquisaDTO(
    int Id,
    TipoImovel TipoImovel,
    decimal Area,
    byte Quartos,
    byte VagasGaragem,
    decimal Valor
);

public record ImovelPesquisaPaginacaoDTO(
    int RegistrosPorPagina,
    int TotalLinhas,
    ImovelPesquisaDTO[] Imoveis
);