using Aplicacao.Imobiliaria.DTOs;

namespace Aplicacao.Imobiliaria.Interfaces;

public interface IImovelService {
    Task<IEnumerable<ImovelDTO>> ObterImoveis();
    Task<ImovelDTO> ObterPorId(int? id);
    Task<int> Criar(ImovelDTO ImovelDTO);
    Task Excluir(int? id);
    Task Atualizar(int id, ImovelDTO ImovelDTO);
}