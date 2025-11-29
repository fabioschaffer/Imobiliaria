using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Servicos;
using Dominio.Entidades.Imobiliaria;
using Dominio.Enums;
using Moq;
using Repositorio.Interfaces;
using Xunit;

namespace TestesUnitarios {
    public class ImovelServiceTests {
        private readonly Mock<IImovelRepository> imovelRepo;
        private readonly Mock<ICaracteristicaRepository> caracteristicaRepo;
        private readonly ImovelService _ImovelService;

        public ImovelServiceTests() {
            imovelRepo = new Mock<IImovelRepository>();
            caracteristicaRepo = new Mock<ICaracteristicaRepository>();
            _ImovelService = new ImovelService(imovelRepo.Object, caracteristicaRepo.Object);
        }

        [Fact]
        public async Task CriarImovel_VerificaSeCriouComSucesso() {

            // Arrange
            var imovelDTO = new ImovelDTO(
               Id: 0,
               TipoImovel: TipoImovel.Casa,
               Area: 100,
               Quartos: 3,
               VagasGaragem: 2,
               Valor: 200000,
               ImovelCaracteristicas: Array.Empty<ImovelCaracteristicaDTO>()
            );
            var imovel = new Imovel();

            //imovel.Atualizar(
            //    imovelDTO.TipoImovel,
            //    imovelDTO.Area,
            //    imovelDTO.Quartos,
            //    imovelDTO.VagasGaragem,
            //    imovelDTO.Valor
            //);

            // Act
            var resultado = await _ImovelService.Criar(imovelDTO);

            // Assert
            imovelRepo.Verify(r => r.Criar(It.IsAny<Imovel>()), Times.Once);

            //Assert.NotNull(resultado);

            //Assert.Equal(imovel.Id, resultado.Id);

            //imovelRepo.Verify(imovelRepo => imovelRepo.Criar(It.Is<Imovel>(i =>
            //    i.TipoImovel == imovelDTO.TipoImovel &&
            //    i.Area == imovelDTO.Area &&
            //    i.Quartos == imovelDTO.Quartos &&
            //    i.VagasGaragem == imovelDTO.VagasGaragem &&
            //    i.Valor == imovelDTO.Valor
            //)), Times.Once);

        }


     


    }
}
