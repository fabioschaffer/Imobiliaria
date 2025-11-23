namespace Dominio.Entidades {
    public class UnidadeFederacao {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public UnidadeFederacao(string nome) {
            Nome = nome;
        }

        public void Atualizar(string nome) {
            Nome = nome;
        }

    }
}