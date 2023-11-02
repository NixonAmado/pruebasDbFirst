
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class MunicipioConfiguration:IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("municipio");

        builder.HasIndex(e => e.IdDepartamentoFk, "IX_municipio_IdDepartamentoFk");

        builder.Property(e => e.Nombre)
            .HasMaxLength(50)
            .HasColumnName("nombre");

        builder.HasOne(d => d.IdDepartamentoFkNavigation).WithMany(p => p.Municipios)
            .HasForeignKey(d => d.IdDepartamentoFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}