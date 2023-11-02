
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class EmpleadoConfiguration:IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.ToTable("empleado");
        builder.HasIndex(e => e.IdCargoFk, "IX_empleado_IdCargoFk");
        builder.HasIndex(e => e.IdMunicipioFk, "IX_empleado_IdMunicipioFk");
        builder.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
        builder.Property(e => e.Nombre)
            .HasMaxLength(50)
            .HasColumnName("nombre");
        builder.HasOne(d => d.IdCargoFkNavigation).WithMany(p => p.Empleados)
            .HasForeignKey(d => d.IdCargoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_empleado_Cargos_IdCargoFk");
        builder.HasOne(d => d.IdMunicipioFkNavigation).WithMany(p => p.Empleados)
            .HasForeignKey(d => d.IdMunicipioFk)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}