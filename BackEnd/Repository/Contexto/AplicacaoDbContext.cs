using Dominio.Entidades.EnderecoNS;
using Dominio.Entidades.Imobiliaria;
using Dominio.Entidades.Testes;
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

        modelBuilder.Entity<T_Orcamento>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.HasOne(o => o.Servicos)
                  .WithOne(s => s.Orcamento)
                  .HasForeignKey<T_Orcamento_Servicos>(s => s.OrcamentoId);
        });

        modelBuilder.Entity<T_Orcamento_Servicos>(entity =>
        {
            entity.HasKey(s => s.OrcamentoId);
            entity.Property(s => s.OrcamentoId).ValueGeneratedNever();
        });
    }

    public DbSet<UnidadeFederacao> UnidadesFederacao { get; set; }

    public DbSet<Imovel> Imoveis { get; set; }
    public DbSet<Caracteristica> Caracteristicas { get; set; }
    public DbSet<ImovelCaracteristica> ImoveisCaracteristicas { get; set; }
    public DbSet<Dominio.Entidades.Imovel.Tipo> ImovelTipos { get; set; }

    public DbSet<Dominio.Entidades.Testes.T_Orcamento> Orcamentos { get; set; }
    public DbSet<Dominio.Entidades.Testes.T_Orcamento_Servicos> OrcamentoServicos { get; set; }

    public DbSet<Dominio.Entidades.Seguranca.RefreshToken> RefreshTokens { get; set; }
}