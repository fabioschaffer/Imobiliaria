namespace Dominio.Entidades {
    public class Cidade {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public UnidadeFederacao UnidadeFederacao { get; private set; }

        public Cidade() {
            
        }

        public Cidade(int id, string nome, UnidadeFederacao unidadeFederacao) {
            Id = id;
            Nome = nome;
            UnidadeFederacao = unidadeFederacao;
        }
    }
}