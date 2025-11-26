using Aplicacao.Endereco.DTOs;
using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Dominio.Entidades.EnderecoNS;
using Dominio.Entidades.Imobiliaria;
using Repositorio.Interfaces;

namespace Aplicacao.Imobiliaria.Servicos;
public class ImovelService : IImovelService {

    private IImovelRepository ImovelRepository;

    public ImovelService(IImovelRepository ImovelRepository) {
        this.ImovelRepository = ImovelRepository;
    }

    public async Task<int> Criar(ImovelDTO ImovelDTO) {

        var Imovel = new Dominio.Entidades.Imobiliaria.Imovel(ImovelDTO.TipoImovel, ImovelDTO.Area, ImovelDTO.Quartos, ImovelDTO.VagasGaragem, ImovelDTO.Valor);

        await ImovelRepository.Criar(Imovel);

        return Imovel.Id;
    }

    public async Task Atualizar(int id, ImovelDTO ImovelDTO) {
        var Imovel = await ImovelRepository.ObterPorId(id);

        if (Imovel == null)
            throw new KeyNotFoundException($"Imovel with Id {id} not found.");

        Imovel.Atualizar(ImovelDTO.TipoImovel, ImovelDTO.Area, ImovelDTO.Quartos, ImovelDTO.VagasGaragem, ImovelDTO.Valor);

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
