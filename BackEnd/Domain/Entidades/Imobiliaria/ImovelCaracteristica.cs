using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Imobiliaria;

[Table(nameof(ImovelCaracteristica), Schema = nameof(Schemas.Imobiliaria))]
public class ImovelCaracteristica {
    public int Id { get; private set; }
    public int ImovelId { get; private set; }
    public Imovel Imovel { get; private set; }
    public int CaracteristicaId { get; private set; }
    public Caracteristica Caracteristica { get; private set; }

    private ImovelCaracteristica() { }

    public ImovelCaracteristica(Imovel imovel, Caracteristica caracteristica) {
        Imovel = imovel;
        ImovelId = imovel.Id;
        Caracteristica = caracteristica;
        CaracteristicaId = caracteristica.Id;
    }
}