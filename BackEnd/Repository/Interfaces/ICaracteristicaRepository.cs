using Dominio.Entidades.Imobiliaria;
using Dominio.Entidades.Imovel;

namespace Repositorio.Interfaces;

public interface ICaracteristicaRepository {
    Task<IEnumerable<Caracteristica>> ObterTodas();
}