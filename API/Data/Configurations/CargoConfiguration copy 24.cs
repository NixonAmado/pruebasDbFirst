
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class CargoConfiguration:IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("cargos");

        builder.Property(e => e.Descripcion)
            .HasMaxLength(50)
            .HasColumnName("descripcion");
        
        builder.Property(e => e.SueldoBase).HasColumnName("sueldo_base");

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Cargos)
        .HasForeignKey(p => p.IdMunicipioFk);
    }
}