using Dominio.Entidades.Imobiliaria;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;

namespace Repositorio.Repositorios;
public class CaracteristicaRepository : ICaracteristicaRepository {

    private AplicacaoDbContext contexto;

    public CaracteristicaRepository(AplicacaoDbContext contexto) {
        this.contexto = contexto;
    }
    public async Task<IEnumerable<Caracteristica>> ObterTodas() {
        return await contexto.Caracteristicas.ToListAsync();
    }
}