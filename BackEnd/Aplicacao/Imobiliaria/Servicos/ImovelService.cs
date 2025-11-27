using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Dominio.Entidades.Imobiliaria;
using Repositorio.Interfaces;

namespace Aplicacao.Imobiliaria.Servicos;
public class ImovelService : IImovelService {

    private IImovelRepository ImovelRepository;
    private ICaracteristicaRepository caracteristicaRepository;

    public ImovelService(IImovelRepository ImovelRepository, ICaracteristicaRepository caracteristicaRepository) {
        this.ImovelRepository = ImovelRepository;
        this.caracteristicaRepository = caracteristicaRepository;
    }

    public async Task<int> Criar(ImovelDTO imovelDTO)
    {
        var imovel = new Imovel();

        await AtualizarImovelComDTO(imovelDTO, imovel);

        await ImovelRepository.Criar(imovel);

        return imovel.Id;
    }

    public async Task Atualizar(int id, ImovelDTO ImovelDTO) {
        var imovel = await ImovelRepository.ObterPorId(id);

        if (imovel == null)
            throw new KeyNotFoundException($"Imovel with Id {id} not found.");

        await AtualizarImovelComDTO(ImovelDTO, imovel);

        await ImovelRepository.Atualizar(imovel);
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

        return new ImovelDTO (
            Imovel.Id,
            Imovel.TipoImovel,  
            Imovel.Area,
            Imovel.Quartos,
            Imovel.VagasGaragem,
            Imovel.Valor,
            null
        );
    }
    public async Task<IEnumerable<ImovelDTO>> ObterImoveis() {
        var unidadesFederacao = await ImovelRepository.Obter();

        return unidadesFederacao.Select(i => new ImovelDTO(
            i.Id,
            i.TipoImovel,
            i.Area,
            i.Quartos,
            i.VagasGaragem,
            i.Valor,
            null
        ));
    }

    private async Task AtualizarImovelComDTO(ImovelDTO imovelDTO, Imovel imovel)
    {
        var caracteristicas = await caracteristicaRepository.ObterTodas();

        imovel.Atualizar(imovelDTO.TipoImovel, imovelDTO.Area, imovelDTO.Quartos, imovelDTO.VagasGaragem, imovelDTO.Valor);

        // --- REMOVER ---
        var novos_IC_Ids = imovelDTO.ImovelCaracteristicas.Select(c => c.ImovelCaracteristicaId).ToList() ?? new List<int>();
        var paraRemover = imovel.ImoveisCaracteristicas.Where(ic => !novos_IC_Ids.Contains(ic.CaracteristicaId));
        foreach (var ic in paraRemover)
            imovel.RemoverCaracteristica(ic);

        // --- ADICIONAR ---
        var paraAdicionar = imovelDTO.ImovelCaracteristicas.Where(ic => ic.ImovelCaracteristicaId == 0);
        foreach (var ic in paraAdicionar)
        {
            var caracteristica = caracteristicas.FirstOrDefault(c => c.Id == ic.CaracteristicaId);
            imovel.AdicionarCaracteristica(caracteristica);
        }
    }
}
