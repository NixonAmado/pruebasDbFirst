
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class DepartamentoConfiguration:IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.ToTable("departamento");
        builder.HasIndex(e => e.IdPaisFk, "IX_departamento_IdPaisFk");
        builder.Property(e => e.Nombre)
            .HasMaxLength(50)
            .HasColumnName("nombre");
        builder.HasOne(d => d.IdPaisFkNavigation).WithMany(p => p.Departamentos)
            .HasForeignKey(d => d.IdPaisFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}