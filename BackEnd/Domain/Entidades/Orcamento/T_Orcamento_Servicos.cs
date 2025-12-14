namespace Dominio.Entidades.Testes;

public class T_Orcamento_Servicos
{
    public int OrcamentoId { get; private set; }
    public int preco_hora_pintura { get; set; }
    public int quantidade_horas_pintura { get; set; }
    public T_Orcamento Orcamento { get; set; }
}