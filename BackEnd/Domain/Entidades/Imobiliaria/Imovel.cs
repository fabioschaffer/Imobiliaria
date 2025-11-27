using Dominio.Entidades.EnderecoNS;
using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using System.Linq;

namespace Dominio.Entidades.Imobiliaria;

[Table(nameof(Imovel), Schema = nameof(Schemas.Imobiliaria))]
public class Imovel {
    public int Id { get; private set; }
    public TipoImovel TipoImovel { get; private set; }
    public decimal Area { get; private set; }
    public byte Quartos { get; private set; }
    public byte VagasGaragem { get; private set; }
    public decimal Valor { get; private set; }
    public Endereco Endereco { get; private set; }
    public ICollection<ImovelCaracteristica> ImoveisCaracteristicas { get; private set; }
    public Imovel() { }

    public void Atualizar(TipoImovel tipoImovel, decimal area, byte quartos, byte vagasGaragem, decimal valor) {
        TipoImovel = tipoImovel;
        Area = area;
        Quartos = quartos;
        VagasGaragem = vagasGaragem;
        Valor = valor;
    }

    public void AdicionarCaracteristica(Caracteristica caracteristica) {
        var imovelCaracteristica = new ImovelCaracteristica(this, caracteristica);
        ImoveisCaracteristicas.Add(imovelCaracteristica);
    }

    public void RemoverCaracteristica(ImovelCaracteristica imovelCaracteristica) {
        ImoveisCaracteristicas.Remove(imovelCaracteristica);
    }

}