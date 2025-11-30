using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Servicos;
using Dominio.Entidades.Imobiliaria;
using Dominio.Enums;
using Moq;
using Repositorio.Interfaces;
using Xunit;

namespace TestesUnitarios.Service {
    public class ImovelService_Tests {

        private readonly Mock<IImovelRepository> ImovelRepo;
        private readonly ImovelService ImovelService;

        public ImovelService_Tests() {
            ImovelRepo = new Mock<IImovelRepository>();
            ImovelService = new ImovelService(ImovelRepo.Object);
        }

        [Fact]
        public async Task CriarImovel_VerificaSeChamouRepositorio() {
            // Arrange
            ImovelDTO dto = CriaDTO();

            // Act
            var resultado = await ImovelService.Criar(dto);

            // Assert
            ImovelRepo.Verify(r => r.Criar(It.IsAny<Imovel>()), Times.Once);
        }

        [Fact]
        public async Task CriarImovel_VerificaDadosImovelCriado() {
            // Arrange
            ImovelDTO dto = CriaDTO_ComCaracteristica();

            // Act
            var imovelCriado = await ImovelService.Criar(dto);

            // Assert
            Assert.NotNull(imovelCriado);
            Assert.Equal(dto.TipoImovel, imovelCriado.TipoImovel);
            Assert.Equal(dto.Area, imovelCriado.Area);
            Assert.Equal(dto.Quartos, imovelCriado.Quartos);
            Assert.Equal(dto.VagasGaragem, imovelCriado.VagasGaragem);
            Assert.Equal(dto.Valor, imovelCriado.Valor);
            Assert.Equal(dto.ImovelCaracteristicas.Length, imovelCriado.ImoveisCaracteristicas.ToArray().Length);
        }

        [Fact]
        public async Task RemoverCaracteristica_CaracteristicaDoImovelRemovida() {
            // Arrange
            ImovelDTO dtoSemCaract = CriaDTO();
            ImovelDTO dtoComCaract = CriaDTO_ComCaracteristica();

            // Act
            var imovelCriado = await ImovelService.Criar(dtoComCaract);

            // Assert
            Assert.True(imovelCriado.ImoveisCaracteristicas.Count == 1);
        }

        [Fact]
        public async Task AtualizarImovel_CaracteristicaAdicionada_CarracteristicaRemovida() {

            // Arrange
            ImovelDTO dto = CriaDTO_ComCaracteristica_A_Adicionar_E_A_Remover();
            
            var imovel = CriaImovelComCaracteristica(dto.Id,1, 100);

            ImovelRepo.Setup(r => r.ObterPorId(dto.Id)).ReturnsAsync(imovel);

            // Act
            var imovelAtualizado = await ImovelService.Atualizar(dto.Id, dto);

            // Assert
            Assert.True(imovelAtualizado.ImoveisCaracteristicas.Count == 1);
            Assert.Equal(imovelAtualizado.ImoveisCaracteristicas.First().CaracteristicaId, 2);
        }


        private ImovelDTO CriaDTO() {
            return new ImovelDTO(
                       Id: 0,
                       TipoImovel: TipoImovel.Casa,
                       Area: 100,
                       Quartos: 3,
                       VagasGaragem: 2,
                       Valor: 200000,
                       ImovelCaracteristicas: Array.Empty<ImovelCaracteristicaDTO>()
                    );
        }

        private ImovelDTO CriaDTO_ComCaracteristica() {
            return new ImovelDTO(
                       Id: 0,
                       TipoImovel: TipoImovel.Casa,
                       Area: 100,
                       Quartos: 3,
                       VagasGaragem: 2,
                       Valor: 200000,
                       ImovelCaracteristicas: new List<ImovelCaracteristicaDTO> {
                           new ImovelCaracteristicaDTO(
                               ImovelCaracteristicaId: 0,
                               CaracteristicaId: 1
                           )
                       }.ToArray()
                    );
        }

        private ImovelDTO CriaDTO_ComCaracteristica_A_Adicionar_E_A_Remover() {
            return new ImovelDTO(
                       Id: 1,
                       TipoImovel: TipoImovel.Casa,
                       Area: 100,
                       Quartos: 3,
                       VagasGaragem: 2,
                       Valor: 200000,
                       ImovelCaracteristicas: new List<ImovelCaracteristicaDTO> {
                           new ImovelCaracteristicaDTO(
                               ImovelCaracteristicaId: 0,
                               CaracteristicaId: 2
                           )
                       }.ToArray()
                    );
        }

        private Imovel CriaImovelComCaracteristica(int imovelId, int caracteristicaId, int imovelCaracteristicaId) {
            var imovel = new Imovel();

            // Força o Id usando reflexão
            typeof(Imovel)
                .GetProperty("Id")
                .SetValue(imovel, imovelId);

            var imovelCaracteristica = new ImovelCaracteristica(imovel, caracteristicaId);

            // Força o Id usando reflexão
            typeof(ImovelCaracteristica)
                .GetProperty("Id")
                .SetValue(imovelCaracteristica, imovelCaracteristicaId);

            // Adiciona a característica à lista privada usando reflexão
            var imoveisCaracteristicasField = typeof(Imovel)
                .GetField("_imoveisCaracteristicas", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var imoveisCaracteristicasList = (List<ImovelCaracteristica>)imoveisCaracteristicasField.GetValue(imovel)!;
            imoveisCaracteristicasList.Add(imovelCaracteristica);

            return imovel;
        }
    }
}