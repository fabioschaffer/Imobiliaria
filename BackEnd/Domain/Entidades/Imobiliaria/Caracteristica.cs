using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Imobiliaria;

[Table(nameof(Caracteristica), Schema = nameof(Schemas.Imobiliaria))]
public class Caracteristica {
    public int Id { get; private set; }
    public string Descricao { get; private set; }
    public ICollection<ImovelCaracteristica> ImoveisCaracteristicasBB { get; private set; }

}
