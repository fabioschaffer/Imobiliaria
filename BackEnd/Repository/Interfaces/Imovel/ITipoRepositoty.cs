using Dominio.Entidades.Imovel;

namespace Repositorio.Interfaces.ImovelNS;

public interface ITipoRepository {
    Task<IEnumerable<Tipo>> ObterTodos();
}