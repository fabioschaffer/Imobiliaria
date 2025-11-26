using Dominio.Entidades.EnderecoNS;
using Dominio.Enums;

namespace Aplicacao.Imobiliaria.DTOs;
public class ImovelDTO {
    public int Id { get;  set; }
    public TipoImovel TipoImovel { get;  set; }
    public decimal Area { get;  set; }
    public byte Quartos { get; set; }
    public byte VagasGaragem { get; set; }
    public decimal Valor { get; set; }
}