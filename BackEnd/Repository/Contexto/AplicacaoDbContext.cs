using Dominio.Entidades.EnderecoNS;
using Dominio.Entidades.Imobiliaria;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto;
public class AplicacaoDbContext : DbContext {

    public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options)
      : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicacaoDbContext).Assembly);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
            entity.SetTableName(entity.ClrType.Name);
    }

    public DbSet<UnidadeFederacao> UnidadesFederacao { get; set; }

    public DbSet<Imovel> Imoveis { get; set; }
    public DbSet<Caracteristica> Caracteristicas { get; set; }
    public DbSet<ImovelCaracteristica> ImoveisCaracteristicas { get; set; }
}