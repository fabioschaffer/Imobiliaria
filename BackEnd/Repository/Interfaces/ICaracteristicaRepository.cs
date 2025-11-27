using Dominio.Entidades.Imobiliaria;

namespace Repositorio.Interfaces;

public interface ICaracteristicaRepository {
    Task<IEnumerable<Caracteristica>> ObterTodas();
}