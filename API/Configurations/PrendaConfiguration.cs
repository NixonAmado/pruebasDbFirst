
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class PrendaConfiguration:IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("prenda");

        builder.HasIndex(e => e.IdEstadoFk, "IX_prenda_IdEstadoFk");

        builder.HasIndex(e => e.IdGeneroFk, "IX_prenda_IdGeneroFk");

        builder.HasIndex(e => e.IdTipoProteccion, "IX_prenda_IdTipoProteccion");

        builder.Property(e => e.Codigo)
            .HasMaxLength(50)
            .HasDefaultValueSql("''");
        builder.Property(e => e.Nombre).HasMaxLength(50);

        builder.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Prenda)
            .HasForeignKey(d => d.IdEstadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.IdGeneroFkNavigation).WithMany(p => p.Prenda)
            .HasForeignKey(d => d.IdGeneroFk)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.IdTipoProteccionNavigation).WithMany(p => p.Prenda)
            .HasForeignKey(d => d.IdTipoProteccion)
            .OnDelete(DeleteBehavior.ClientSetNull);
}
}