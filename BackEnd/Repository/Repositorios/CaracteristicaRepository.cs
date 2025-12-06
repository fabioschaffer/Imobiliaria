using Dominio.Entidades.Imobiliaria;
using Dominio.Entidades.Imovel;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using Repositorio.Interfaces.ImovelNS;

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