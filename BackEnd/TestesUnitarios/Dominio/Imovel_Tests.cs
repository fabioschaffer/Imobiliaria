using Xunit;
using Dominio.Entidades.Imobiliaria;
using Dominio.Enums;

namespace TestesUnitarios.Dominio;

public class Imovel_Tests {
    [Fact]
    public void Atualizar_DeveAtualizarTodosOsCampos() {
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
    public void AdicionarCaracteristica_DeveAdicionarRelacionamento() {
        // Arrange
        var imovel = new Imovel();
        var caracteristicaId = 1;

        // Act
        imovel.AdicionarCaracteristica(caracteristicaId);

        // Assert
        Assert.Single(imovel.ImoveisCaracteristicas);
        Assert.Equal(imovel, imovel.ImoveisCaracteristicas.First().Imovel);
        Assert.Equal(caracteristicaId, imovel.ImoveisCaracteristicas.First().CaracteristicaId);
    }

    [Fact]
    public void RemoverCaracteristica_DeveRemoverRelacionamento() {
        // Arrange
        var imovel = new Imovel();
        var caracteristicaId = 1;
        imovel.AdicionarCaracteristica(caracteristicaId);
        var imovelCaracteristica = imovel.ImoveisCaracteristicas.First();

        // Act
        imovel.RemoverCaracteristica(imovelCaracteristica.Id);

        // Assert
        Assert.Empty(imovel.ImoveisCaracteristicas);
    }
}