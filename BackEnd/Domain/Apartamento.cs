namespace Domain;
public class Apartamento : Imovel {
    public int NumeroApartamento { get; private set; }

    public Apartamento(string descricao, decimal valor) : base(descricao, valor)
    {
    }
}