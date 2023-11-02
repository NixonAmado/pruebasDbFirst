
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class ClienteConfiguration:IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.ToTable("cliente");
        builder.HasIndex(e => e.IdMunicipioFk, "IX_cliente_IdMunicipioFk");
        builder.HasIndex(e => e.IdTipoPersonaFk, "IX_cliente_IdTipoPersonaFk");
    
        builder.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
        builder.Property(e => e.IdCliente).HasMaxLength(255);
        builder.Property(e => e.Nombre)
            .HasMaxLength(50)
            .HasColumnName("nombre");
    
        builder.HasOne(d => d.IdMunicipioFkNavigation).WithMany(p => p.Clientes)
            .HasForeignKey(d => d.IdMunicipioFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(d => d.IdTipoPersonaFkNavigation).WithMany(p => p.Clientes)
            .HasForeignKey(d => d.IdTipoPersonaFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}