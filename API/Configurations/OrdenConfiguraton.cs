
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class OrdenConfiguration:IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("orden");

        builder.HasIndex(e => e.IdClienteFk, "IX_orden_IdClienteFk");

        builder.HasIndex(e => e.IdEmpleadoFk, "IX_orden_IdEmpleadoFk");

        builder.HasIndex(e => e.IdEstadoFk, "IX_orden_IdEstadoFk");

        builder.Property(e => e.Fecha).HasColumnName("fecha");

        builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.Ordens)
            .HasForeignKey(d => d.IdClienteFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.Ordens)
            .HasForeignKey(d => d.IdEmpleadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Ordens)
            .HasForeignKey(d => d.IdEstadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}