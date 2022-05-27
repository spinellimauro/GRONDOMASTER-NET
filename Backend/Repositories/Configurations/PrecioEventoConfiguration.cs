using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PrecioEventoConfiguration : IEntityTypeConfiguration<PrecioEvento>
{
    public void Configure(EntityTypeBuilder<PrecioEvento> builder)
    {
        builder.Property(precioEvento => precioEvento.Id).ValueGeneratedOnAdd();

        builder.HasKey(precioEvento => new
        {
            precioEvento.Id
        });

        builder
                .Property(precioEvento => precioEvento.NombreEvento)
                .HasColumnType("nvarchar(30)")
                .IsRequired();
    }
}