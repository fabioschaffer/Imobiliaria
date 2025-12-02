using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Servicos;
using Dominio.Entidades.Imobiliaria;
using Dominio.Enums;
using Moq;
using Repositorio.Interfaces;
using Util.Enums;
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
        public async Task CriarImovel_ImoveComDados_VerificaDadosImovelCriado() {
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
        public async Task AtualizarImovel_ImovelComCaracteristiscaAAdicionar_CarracteristicaAdicionada() {

            // Arrange
            ImovelDTO dto = CriaDTO_ComCaracteristica_A_Adicionar();

            var imovel = CriaImovelComCaracteristica(
                dto.Id,
                [new ImovelCaracteristicaRecord(1, 1)]);

            ImovelRepo.Setup(r => r.ObterPorId(dto.Id)).ReturnsAsync(imovel);

            // Act
            var imovelAtualizado = await ImovelService.Atualizar(dto.Id, dto);

            // Assert
            Assert.True(imovelAtualizado.ImoveisCaracteristicas.Count == 2);
            Assert.Contains(imovelAtualizado.ImoveisCaracteristicas, ic => ic.CaracteristicaId == 1);
            Assert.Contains(imovelAtualizado.ImoveisCaracteristicas, ic => ic.CaracteristicaId == 2);
        }

        [Fact]
        public async Task AtualizarImovel_ImovelComCaracteristiscaARemover_CarracteristicaRemovida() {
            // Arrange
            ImovelDTO dto = CriaDTO_ComCaracteristica_A_Remover();

            var imovel = CriaImovelComCaracteristica(
                           dto.Id,
                           new ImovelCaracteristicaRecord[] {
                               new(1, 1),
                               new(2, 2),
                           }
                );

            ImovelRepo.Setup(r => r.ObterPorId(dto.Id)).ReturnsAsync(imovel);

            // Act
            var imovelAtualizado = await ImovelService.Atualizar(dto.Id, dto);

            // Assert
            Assert.True(imovelAtualizado.ImoveisCaracteristicas.Count == 1);
            Assert.Contains(imovelAtualizado.ImoveisCaracteristicas, ic => ic.CaracteristicaId == 1);
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
                               Acao : Acao.Adicionar,
                               ImovelCaracteristicaId: 0,
                               CaracteristicaId: 1
                           )
                       }.ToArray()
                    );
        }

        private ImovelDTO CriaDTO_ComCaracteristica_A_Adicionar() {
            return new ImovelDTO(
                       Id: 1,
                       TipoImovel: TipoImovel.Casa,
                       Area: 100,
                       Quartos: 3,
                       VagasGaragem: 2,
                       Valor: 200000,
                       ImovelCaracteristicas: new List<ImovelCaracteristicaDTO> {
                           new ImovelCaracteristicaDTO(
                               Acao: Acao.Editar,
                               ImovelCaracteristicaId: 1,
                               CaracteristicaId: 1
                           ),
                           new ImovelCaracteristicaDTO(
                               Acao: Acao.Adicionar,
                               ImovelCaracteristicaId: 0,
                               CaracteristicaId: 2
                           )
                       }.ToArray()
                    );
        }

        private ImovelDTO CriaDTO_ComCaracteristica_A_Remover() {
            return new ImovelDTO(
                       Id: 1,
                       TipoImovel: TipoImovel.Casa,
                       Area: 100,
                       Quartos: 3,
                       VagasGaragem: 2,
                       Valor: 200000,
                       ImovelCaracteristicas: new List<ImovelCaracteristicaDTO> {
                           new ImovelCaracteristicaDTO(
                               Acao: Acao.Editar,
                               ImovelCaracteristicaId: 1,
                               CaracteristicaId: 1
                           ),
                           new ImovelCaracteristicaDTO(
                               Acao: Acao.Remover,
                               ImovelCaracteristicaId: 2,
                               CaracteristicaId: 2
                           )
                       }.ToArray()
                    );
        }

        private Imovel CriaImovelComCaracteristica(int imovelId, ImovelCaracteristicaRecord[] imovelCaracteristicas) {

            var imovel = new Imovel();
            typeof(Imovel).GetProperty("Id").SetValue(imovel, imovelId); // Seta o Id por reflexão (pois é privado).

            foreach (var item in imovelCaracteristicas) {
                var imovelCaracteristica = new ImovelCaracteristica(imovel, item.caracteristicaId);
                typeof(ImovelCaracteristica).GetProperty("Id").SetValue(imovelCaracteristica, item.imovelCaracteristicaId); // Seta o Id por reflexão (pois é privado).

                // Adiciona a característica ao imóvel usando reflexão (pois é privado).
                var imoveisCaracteristicasField = typeof(Imovel).GetField("_imoveisCaracteristicas", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var imoveisCaracteristicasList = (List<ImovelCaracteristica>)imoveisCaracteristicasField.GetValue(imovel)!;
                imoveisCaracteristicasList.Add(imovelCaracteristica);
            }

            return imovel;
        }

        public record ImovelCaracteristicaRecord(
            int caracteristicaId,
            int imovelCaracteristicaId
        );
    }
}