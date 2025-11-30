using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.EnderecoNS {

    [Table(nameof(Endereco), Schema = nameof(Schemas.Endereco))]
    public class Endereco {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; private set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
    }
}