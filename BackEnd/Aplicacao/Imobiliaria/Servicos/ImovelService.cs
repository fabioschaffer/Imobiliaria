using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Dominio.Entidades.Imobiliaria;
using Repositorio.Interfaces;
using Util;

namespace Aplicacao.Imobiliaria.Servicos;
public class ImovelService : IImovelService {

    private IImovelRepository ImovelRepository;

    public ImovelService(IImovelRepository ImovelRepository) {
        this.ImovelRepository = ImovelRepository;
    }

    public async Task<Imovel> Criar(ImovelDTO imovelDTO) {
        var imovel = new Imovel();

        AtualizarImovel(imovelDTO, imovel);

        await ImovelRepository.Criar(imovel);

        return imovel;
    }

    public async Task<Imovel> Atualizar(int id, ImovelDTO imovelDTO) {
        var imovel = await ImovelRepository.ObterPorId(id);

        ValidacaoHelper.Validar(imovel == null, $"Imóvel com Id {id} não encontrado.");

        AtualizarImovel(imovelDTO, imovel);

        await ImovelRepository.Atualizar(imovel);

        return imovel;  
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

        return new ImovelDTO(
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

    private void AtualizarImovel(ImovelDTO imovelDTO, Imovel imovel) {
        AtualizarDadosImovel(imovel, imovelDTO);
        AdicionarCaracteristicasImovel(imovel, imovelDTO);
        RemoverCaracteristicasImovel(imovel, imovelDTO);
    }

    private static void AtualizarDadosImovel(Imovel imovel, ImovelDTO dto) {
        imovel.Atualizar(dto.TipoImovel, dto.Area, dto.Quartos, dto.VagasGaragem, dto.Valor);
    }

    private void AdicionarCaracteristicasImovel(Imovel imovel, ImovelDTO dto) {
        var paraAdicionar = dto.ImovelCaracteristicas.Where(ic => ic.ImovelCaracteristicaId == 0).ToList();
        foreach (var ic in paraAdicionar) {
            imovel.AdicionarCaracteristica(ic.CaracteristicaId);
        }
    }

    private void RemoverCaracteristicasImovel(Imovel imovel, ImovelDTO dto) {
        var novos_IC_Ids = dto.ImovelCaracteristicas.Select(s => s.ImovelCaracteristicaId).ToList() ?? new List<int>();
        var paraRemover = imovel.ImoveisCaracteristicas.Where(ic => ic.Id != 0 && !novos_IC_Ids.Contains(ic.CaracteristicaId)).ToList();
        foreach (var ic in paraRemover)
            imovel.RemoverCaracteristica(ic);
    }
}