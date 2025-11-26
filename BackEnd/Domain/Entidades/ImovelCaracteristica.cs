using Dominio.Entidades;

public class ImovelCaracteristica {
    public int Id { get; set; }

    public int ImovelId { get; set; }
    public Imovel Imovel { get; set; }


    public int CaracteristicaId { get; set; }
    public Caracteristica Caracteristica { get; set; }

}
