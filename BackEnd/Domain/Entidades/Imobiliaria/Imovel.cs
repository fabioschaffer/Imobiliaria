using Dominio.Entidades.EnderecoNS;
using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Imobiliaria {

    [Table(nameof(Imovel), Schema = nameof(Schemas.Imobiliaria))]
    public class Imovel {
        public int Id { get; private set; }
        public TipoImovel TipoImovel { get; private set; }
        public decimal Area { get; private set; }
        public byte Quartos { get; set; }
        public byte VagasGaragem { get; set; }
        public decimal Valor { get; set; }
        public Endereco Endereco { get; set; }

        public ICollection<ImovelCaracteristica> ImoveisCaracteristicas { get; set; }

        protected Imovel() {

        }

        protected Imovel(TipoImovel tipoImovel, decimal area, byte quartos, byte vagasGaragem, decimal valor) {
            TipoImovel = tipoImovel;
            Area = area;
            Quartos = quartos;
            VagasGaragem = vagasGaragem;
            Valor = valor;
        }

    }
}