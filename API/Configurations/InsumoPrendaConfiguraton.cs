
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class InsumoPrendaConfiguration:IEntityTypeConfiguration<InsumoPrenda>
{
    public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
    {
        builder.HasKey(e => new { e.IdPrendaFk, e.IdInsumoFk })
            .HasName("PRIMARY")
            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        builder.ToTable("insumo_prendas");

        builder.HasIndex(e => e.IdInsumoFk, "IX_insumo_prendas_IdInsumoFk");

        builder.HasOne(d => d.IdInsumoFkNavigation).WithMany(p => p.InsumoPrenda)
            .HasForeignKey(d => d.IdInsumoFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.IdPrendaFkNavigation).WithMany(p => p.InsumoPrenda)
            .HasForeignKey(d => d.IdPrendaFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}