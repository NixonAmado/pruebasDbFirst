
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class DetalleOrdenConfiguration:IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("detalle_orden");
        
        builder.HasIndex(e => e.IdColorFk, "IX_detalle_orden_IdColorFk");
        builder.HasIndex(e => e.IdEstadoFk, "IX_detalle_orden_IdEstadoFk");
        builder.HasIndex(e => e.IdOrdenFk, "IX_detalle_orden_IdOrdenFk");
        builder.HasIndex(e => e.PrendaId, "IX_detalle_orden_PrendaId");
        
        builder.Property(e => e.CantidadProducida).HasColumnName("cantidad_producida");
        builder.Property(e => e.CantidadProducir).HasColumnName("cantidad_producir");
        
        builder.HasOne(d => d.IdColorFkNavigation).WithMany(p => p.DetalleOrdens)
            .HasForeignKey(d => d.IdColorFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_detalle_orden_Color_IdColorFk");
        
        builder.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.DetalleOrdens)
            .HasForeignKey(d => d.IdEstadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        builder.HasOne(d => d.IdOrdenFkNavigation).WithMany(p => p.DetalleOrdens)
            .HasForeignKey(d => d.IdOrdenFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        builder.HasOne(d => d.Prenda).WithMany(p => p.DetalleOrdens).HasForeignKey(d => d.PrendaId);

    }
}