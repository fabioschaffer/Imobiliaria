namespace Dominio.Entidades {
    public class Endereco {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
    }
}