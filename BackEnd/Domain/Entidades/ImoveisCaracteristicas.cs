namespace Dominio.Entidades;
public class ImoveisCaracteristicas {

    //TODO: Criar índice único composto para ImovelId + ImovelCaracteristicaId.
    //TODO: Rodar migration para criar tabela de junção ImoveisCaracteristicas.

    public int Id { get; set; }

    public Imovel Imovel { get; set; }
    public ImovelCaracteristica ImovelCaracteristica { get; set; }
}
