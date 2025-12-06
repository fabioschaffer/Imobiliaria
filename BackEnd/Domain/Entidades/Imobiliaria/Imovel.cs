using Dominio.Entidades.EnderecoNS;
using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Imobiliaria;

[Table(nameof(Imovel), Schema = nameof(Schemas.Imobiliaria))]
public class Imovel {
    public int Id { get; private set; }
    public TipoImovel TipoImovel { get; private set; }
    public decimal Area { get; private set; }
    public byte Quartos { get; private set; }
    public byte VagasGaragem { get; private set; }
    public decimal Valor { get; private set; }
    public Endereco? Endereco { get; private set; }

    private readonly List<ImovelCaracteristica> _imoveisCaracteristicas = new();
    public IReadOnlyCollection<ImovelCaracteristica> ImoveisCaracteristicas => _imoveisCaracteristicas;

    public Imovel() { }

    public void Atualizar(TipoImovel tipoImovel, decimal area, byte quartos, byte vagasGaragem, decimal valor) {
        TipoImovel = tipoImovel;
        Area = area;
        Quartos = quartos;
        VagasGaragem = vagasGaragem;
        Valor = valor;
    }

    public void AdicionarCaracteristica(int caracteristicaId) {
        var imovelCaracteristica = new ImovelCaracteristica(this, caracteristicaId);
        _imoveisCaracteristicas.Add(imovelCaracteristica);
    }

    public void RemoverCaracteristica(int imovelCaracteristicaId) {
        var imovelCaracteristica = _imoveisCaracteristicas.FirstOrDefault(ic => ic.Id == imovelCaracteristicaId);
        _imoveisCaracteristicas.Remove(imovelCaracteristica);
    }
}