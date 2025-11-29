using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.EnderecoNS {

    [Table(nameof(UnidadeFederacao), Schema = nameof(Schemas.Endereco))]
    public class UnidadeFederacao {

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public UnidadeFederacao(string nome) {
            Atualizar(nome);
        }

        public void Atualizar(string nome) {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException(nameof(nome));

            Nome = nome;
        }
    }
}