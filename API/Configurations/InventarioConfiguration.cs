
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class InventarioConfiguration:IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("inventario");

        builder.HasIndex(e => e.IdPrendaFk, "IX_inventario_IdPrendaFk");

        builder.Property(e => e.CodInv).HasMaxLength(255);

        builder.HasOne(d => d.IdPrendaFkNavigation).WithMany(p => p.Inventarios)
            .HasForeignKey(d => d.IdPrendaFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasMany(d => d.IdTallaFks).WithMany(p => p.IdInvFks)
            .UsingEntity<Dictionary<string, object>>(
                "InventarioTalla",
                r => r.HasOne<Talla>().WithMany()
                    .HasForeignKey("IdTallaFk")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                l => l.HasOne<Inventario>().WithMany()
                    .HasForeignKey("IdInvFk")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                j =>
                {
                    j.HasKey("IdInvFk", "IdTallaFk")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    j.ToTable("inventario_talla");
                    j.HasIndex(new[] { "IdTallaFk" }, "IX_inventario_talla_IdTallaFk");
                });
}
}