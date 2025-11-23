using Aplicacao.DTOs;

namespace Aplicacao.Interfaces;

public interface IImovelService {
    Task<IEnumerable<ImovelDTO>> Obter();
    Task<ImovelDTO> ObterPorId(int? id);
    Task<int> Criar(ImovelDTO ImovelDTO);
    Task Excluir(int? id);
    Task Atualizar(int id, ImovelDTO ImovelDTO);
}