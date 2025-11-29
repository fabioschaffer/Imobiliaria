using Dominio.Entidades.EnderecoNS;
using Xunit;

namespace TestesUnitarios;

using Dominio.Entidades.Imobiliaria;
using Dominio.Enums;
using Xunit;

public class ImovelTests
{
    [Fact]
    public void Atualizar_DeveAtualizarTodosOsCampos()
    {
        // Arrange
        var imovel = new Imovel();

        var tipoImovel = TipoImovel.Casa;
        decimal area = 120.5m;
        byte quartos = 3;
        byte vagasGaragem = 2;
        decimal valor = 350000m;

        // Act
        imovel.Atualizar(tipoImovel, area, quartos, vagasGaragem, valor);

        // Assert
        Assert.Equal(tipoImovel, imovel.TipoImovel);
        Assert.Equal(area, imovel.Area);
        Assert.Equal(quartos, imovel.Quartos);
        Assert.Equal(vagasGaragem, imovel.VagasGaragem);
        Assert.Equal(valor, imovel.Valor);
    }

    [Fact]
    public void AdicionarCaracteristica_DeveAdicionarRelacionamento()
    {
        // Arrange
        var imovel = new Imovel();
        var caracteristica = new Caracteristica("Piscina");

        // Act
        imovel.AdicionarCaracteristica(caracteristica);

        // Assert
        Assert.Single(imovel.ImoveisCaracteristicas);
        Assert.Equal(imovel, imovel.ImoveisCaracteristicas.First().Imovel);
        Assert.Equal(caracteristica, imovel.ImoveisCaracteristicas.First().Caracteristica);
    }

    [Fact]
    public void RemoverCaracteristica_DeveRemoverRelacionamento()
    {
        // Arrange
        var imovel = new Imovel();
        var caracteristica = new Caracteristica("Piscina");
        imovel.AdicionarCaracteristica(caracteristica);
        var imovelCaracteristica = imovel.ImoveisCaracteristicas.First();

        // Act
        imovel.RemoverCaracteristica(imovelCaracteristica);

        // Assert
        Assert.Empty(imovel.ImoveisCaracteristicas);
    }

    [Fact]
    public void AdicionarCaracteristica_QuandoCaracteristicaNula_DeveLancarExcecao()
    {
        // Arrange
        var imovel = new Imovel();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            imovel.AdicionarCaracteristica(null!);
        });
    }
}