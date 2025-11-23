using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto;
public class AplicacaoDbContext : DbContext {

    public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options)
      : base(options) {
    }

    public DbSet<UnidadeFederacao> UnidadesFederacao { get; set; }
    public DbSet<ImovelCaracteristica> ImovelCaracteristicas { get; set; }
    public DbSet<Imovel> Imoveis { get; set; }
    public DbSet<ImoveisCaracteristicas> ImoveisCaracteristicas { get; set; }

}