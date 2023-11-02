
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;
namespace API.Data;

class ColorConfiguration:IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {

        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.ToTable("color");
        builder.Property(e => e.Descripcion).HasMaxLength(255);
    }
}