using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.EnderecoNS {
    
    [Table(nameof(Cidade), Schema = nameof(Schemas.Endereco))]
    
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