using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data;

class InsumoConfiguration:IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("insumo");

        builder.Property(e => e.Nombre)
            .HasMaxLength(50)
            .HasColumnName("nombre");
        builder.Property(e => e.StockMax).HasColumnName("stock_max");
        builder.Property(e => e.StockMin).HasColumnName("stock_min");
        builder.Property(e => e.ValorUnit).HasColumnName("valor_unit");

        builder.HasMany(d => d.IdProveedorFks).WithMany(p => p.IdInsumoFks)
        .UsingEntity<Dictionary<string, object>>(
            "InsumoProveedor",
            r => r.HasOne<Proveedor>().WithMany()
                .HasForeignKey("IdProveedorFk")
                .OnDelete(DeleteBehavior.ClientSetNull),
            l => l.HasOne<Insumo>().WithMany()
                .HasForeignKey("IdInsumoFk")
                .OnDelete(DeleteBehavior.ClientSetNull),
            j =>
            {
                j.HasKey("IdInsumoFk", "IdProveedorFk")
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                j.ToTable("insumo_proveedor");
                j.HasIndex(new[] { "IdProveedorFk" }, "IX_insumo_proveedor_IdProveedorFk");
            });
    }
}