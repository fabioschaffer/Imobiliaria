using Dominio.Entidades.Imobiliaria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Contexto;
public class ImoveisCaracteristicasConfiguration : IEntityTypeConfiguration<ImovelCaracteristica> {
    public void Configure(EntityTypeBuilder<ImovelCaracteristica> builder) {

        builder
            .HasOne(ic => ic.Imovel)
            .WithMany(i => i.ImoveisCaracteristicas)
            .HasForeignKey(ic => ic.ImovelId);

        builder
            .HasOne(ic => ic.Caracteristica)
            .WithMany(c => c.ImoveisCaracteristicas)
            .HasForeignKey(ic => ic.CaracteristicaId);

        builder.HasIndex(ic => new { ic.ImovelId, ic.CaracteristicaId }).IsUnique();
    }
}