using Dominio.Entidades.EnderecoNS;
using Xunit;

namespace TestesUnitarios;

public class UnidadeFederacaoTests {

    [Fact()]
    public void Criar_UF_DeveCriarUFCorretamente() {
        //Arrange
        var nomeUF = "São Paulo";

        //Act
        var uf = new UnidadeFederacao(nomeUF);

        //Assert
        Assert.Equal(nomeUF, uf.Nome);

    }

    [Fact()]
    public void Atualizar_UF_DeveAtualizarUFCorretamente() {
        //Arrange
        var UFInicial = "São Paulo";
        var novaUF = "Rio G.";

        //Act
        var uf = new UnidadeFederacao(UFInicial);
        uf.Atualizar(novaUF);

        //Assert
        Assert.Equal(novaUF, uf.Nome);

    }
}
