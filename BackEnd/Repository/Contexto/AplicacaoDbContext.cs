using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto;
public class AplicacaoDbContext : DbContext {

    public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options)
      : base(options) {
    }

    public DbSet<UnidadeFederacao> UnidadesFederacao { get; set; }

}