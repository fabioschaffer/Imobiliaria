using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Dominio.Entidades.Imobiliaria;
using Repositorio.Interfaces;
using Util.Enums;
using Util.Validacoes;

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

        var imovel = await ImovelRepository.ObterPorId(id);

        if (imovel == null) {
            throw new KeyNotFoundException($"Imovel with Id {id} not found.");
        }

        var caracteristicas = imovel.ImoveisCaracteristicas
            .Select(ic => new ImovelCaracteristicaDTO(Acao.NaoDefinido, ic.Id, ic.CaracteristicaId, ic.Caracteristica.Descricao))
            .ToArray();

        return new ImovelDTO(
            imovel.Id,
            imovel.TipoImovel,
            imovel.Area,
            imovel.Quartos,
            imovel.VagasGaragem,
            imovel.Valor,
            caracteristicas
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
        var paraAdicionar = dto.Caracteristicas.Where(ic => ic.Acao == Acao.Adicionar).ToList();
        foreach (var ic in paraAdicionar) {
            imovel.AdicionarCaracteristica(ic.CaracteristicaId);
        }
    }

    private void RemoverCaracteristicasImovel(Imovel imovel, ImovelDTO dto) {
        var paraRemover = dto.Caracteristicas.Where(ic => ic.Acao == Acao.Remover).ToList();
        foreach (var ic in paraRemover)
            imovel.RemoverCaracteristica(ic.ImovelCaracteristicaId);
    }
}