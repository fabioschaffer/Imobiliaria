using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto;
public class AplicacaoDbContext : DbContext {

    public DbSet<UnidadeFederacao> UnidadesFederacao { get; set; }

}