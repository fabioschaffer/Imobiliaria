namespace Dominio.Entidades;
public class Caracteristica {
    public int Id { get; set; }
    public string Descricao { get; set; }
    public ICollection<ImovelCaracteristica> ImoveisCaracteristicasBB { get; set; }

}
