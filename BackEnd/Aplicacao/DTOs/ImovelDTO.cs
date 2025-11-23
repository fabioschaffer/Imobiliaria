using Dominio.Entidades;
using Dominio.Enums;

namespace Aplicacao.DTOs;
public class ImovelDTO {
    public int Id { get; private set; }
    public TipoImovel TipoImovel { get; private set; }
    public decimal Area { get; private set; }
    public byte Quartos { get; set; }
    public byte VagasGaragem { get; set; }
    public decimal Valor { get; set; }
    public Endereco Endereco { get; set; }
    public ImovelCaracteristica[] Caracteristicas { get; set; }
}