using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Dominio.Entidades.Imobiliaria;
using Repositorio.Interfaces;

namespace Aplicacao.Imobiliaria.Servicos;
public class ImovelService : IImovelService {

    private IImovelRepository ImovelRepository;

    public ImovelService(IImovelRepository ImovelRepository) {
        this.ImovelRepository = ImovelRepository;
    }

    public async Task<int> Criar(ImovelDTO imovelDTO) {
        var imovel = new Imovel();
        imovel.Atualizar(imovelDTO.TipoImovel, imovelDTO.Area, imovelDTO.Quartos, imovelDTO.VagasGaragem, imovelDTO.Valor);

        // --- REMOVER ---
        var novos_IC_Ids = imovelDTO.ImovelCaracteristicas?.Select(c => c.ImovelCaracteristicaId).ToList() ?? new List<int>();
        var paraRemover = imovel.ImoveisCaracteristicas.Where(ic => !novos_IC_Ids.Contains(ic.CaracteristicaId));
        foreach (var ic in paraRemover)
            imovel.RemoverCaracteristica(ic);

        // --- ADICIONAR ---
        var paraAdicionar = imovelDTO.ImovelCaracteristicas.Where(ic => ic.ImovelCaracteristicaId == 0);
        foreach (var ic in paraAdicionar) {

            //TODO: Continuar aqui.
            imovel.AdicionarCaracteristica(ic);

        }


        await ImovelRepository.Criar(imovel);
        return imovel.Id;
    }

    public async Task Atualizar(int id, ImovelDTO ImovelDTO) {
        var Imovel = await ImovelRepository.ObterPorId(id);

        if (Imovel == null)
            throw new KeyNotFoundException($"Imovel with Id {id} not found.");

        Imovel.Atualizar(ImovelDTO.TipoImovel, ImovelDTO.Area, ImovelDTO.Quartos, ImovelDTO.VagasGaragem, ImovelDTO.Valor, ImovelDTO.ImovelCaracteristicas);

        await ImovelRepository.Atualizar(Imovel);
    }

    public async Task Excluir(int? id) {
        var Imovel = await ImovelRepository.ObterPorId(id);

        if (Imovel == null)
            throw new KeyNotFoundException($"Imovel with Id {id} not found.");

        await ImovelRepository.Excluir(Imovel);
    }

    public async Task<ImovelDTO> ObterPorId(int? id) {
        if (id == null) {
            throw new ArgumentNullException(nameof(id), "Id cannot be null.");
        }

        var Imovel = await ImovelRepository.ObterPorId(id);

        if (Imovel == null) {
            throw new KeyNotFoundException($"Imovel with Id {id} not found.");
        }

        return new ImovelDTO {
            TipoImovel = Imovel.TipoImovel,
            Area = Imovel.Area,
            Quartos = Imovel.Quartos,
            VagasGaragem = Imovel.VagasGaragem,
            Valor = Imovel.Valor
        };
    }
    public async Task<IEnumerable<ImovelDTO>> ObterImoveis() {
        var unidadesFederacao = await ImovelRepository.Obter();

        return unidadesFederacao.Select(i => new ImovelDTO {
            TipoImovel = i.TipoImovel,
            Area = i.Area,
            Quartos = i.Quartos,
            VagasGaragem = i.VagasGaragem,
            Valor = i.Valor
        });
    }
}
