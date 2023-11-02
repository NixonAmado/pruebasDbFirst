
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class ProveedorConfiguration:IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("proveedor");

        builder.HasIndex(e => e.IdMunicipioFk, "IX_proveedor_IdMunicipioFk");

        builder.HasIndex(e => e.IdTipoPersona, "IX_proveedor_IdTipoPersona");

        builder.HasIndex(e => e.NitProveedor, "IX_proveedor_NitProveedor").IsUnique();

        builder.Property(e => e.NitProveedor).HasMaxLength(50);
        builder.Property(e => e.Nombre).HasMaxLength(50);

        builder.HasOne(d => d.IdMunicipioFkNavigation).WithMany(p => p.Proveedors)
            .HasForeignKey(d => d.IdMunicipioFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Proveedors)
            .HasForeignKey(d => d.IdTipoPersona)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}