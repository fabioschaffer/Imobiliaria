using Aplicacao.DTOs.Imovel;
using Aplicacao.Endereco.DTOs;

namespace Aplicacao.Interfaces.ImovelNS;

public interface ITipoService {
    Task<IEnumerable<TipoDTO>> ObterTodos();
}