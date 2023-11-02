
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class EmpresaConfiguration:IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("empresa");

        builder.HasIndex(e => e.IdMunicipioFk, "IX_empresa_IdMunicipioFk");

        builder.Property(e => e.Nit)
                .HasMaxLength(50)
                .HasColumnName("nit");
        builder.Property(e => e.RazonSocial)
                .HasColumnType("text")
                .HasColumnName("razon_social");
        builder.Property(e => e.RepresentanteLegal)
                .HasMaxLength(50)
                .HasColumnName("representante_legal");

        builder.HasOne(d => d.IdMunicipioFkNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdMunicipioFk)
                .OnDelete(DeleteBehavior.ClientSetNull);
        
    }
}