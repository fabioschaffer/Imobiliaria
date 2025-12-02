using Util.Enums;

namespace Aplicacao.Imobiliaria.DTOs;

public record ImovelCaracteristicaDTO (
    Acao Acao,
    int ImovelCaracteristicaId,
    int CaracteristicaId
);