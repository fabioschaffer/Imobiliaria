namespace Domain {
    public class UnidadeFederacao {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public int teste { get; set; }

        public UnidadeFederacao(string nome) {
            Nome = nome;
        }
    }
}