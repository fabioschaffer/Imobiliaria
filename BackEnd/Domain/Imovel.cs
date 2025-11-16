namespace Domain {
    public abstract class Imovel {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; set; }
        public Endereco Endereco { get; set; }

        public Imovel( string descricao, decimal valor) {
            Descricao = descricao;
            Valor = valor;
        }
    }
}