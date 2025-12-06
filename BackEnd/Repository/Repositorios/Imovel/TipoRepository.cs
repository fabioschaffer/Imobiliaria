using Dominio.Entidades.Imobiliaria;
using Dominio.Entidades.Imovel;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using Repositorio.Interfaces.ImovelNS;

namespace Repositorio.Repositorios.ImovelNS;
public class TipoRepository : ITipoRepository {

    private AplicacaoDbContext contexto;

    public TipoRepository(AplicacaoDbContext contexto) {
        this.contexto = contexto;
    }
    public async Task<IEnumerable<Tipo>> ObterTodos() {
        return await contexto.ImovelTipos.ToListAsync();
    }
}