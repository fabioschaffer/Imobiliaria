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
        public async Task CriarImovel_VerificaSeChamouRepositorio() {

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

            // Act
            var resultado = await _ImovelService.Criar(imovelDTO);

            // Assert
            imovelRepo.Verify(r => r.Criar(It.IsAny<Imovel>()), Times.Once);
        }

        [Fact]
        public async Task CriarImovel_VerificaDadosImovelCriado() {

            // Arrange
            var dto = new ImovelDTO(
               Id: 0,
               TipoImovel: TipoImovel.Casa,
               Area: 100,
               Quartos: 3,
               VagasGaragem: 2,
               Valor: 200000,
               ImovelCaracteristicas: Array.Empty<ImovelCaracteristicaDTO>()
            );
            
            // Act
            var resultado = await _ImovelService.Criar(dto);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(dto.TipoImovel, resultado.TipoImovel);
            Assert.Equal(dto.Area, resultado.Area);
            Assert.Equal(dto.Quartos, resultado.Quartos);
            Assert.Equal(dto.VagasGaragem, resultado.VagasGaragem);
            Assert.Equal(dto.Valor, resultado.Valor);
        }
    }
}