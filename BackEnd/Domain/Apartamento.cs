namespace Domain;
public class Apartamento : Imovel {
    public Apartamento(string descricao, decimal valor) : base(descricao, valor)
    {
    }

    public int NumeroApartamento { get; private set; }
}