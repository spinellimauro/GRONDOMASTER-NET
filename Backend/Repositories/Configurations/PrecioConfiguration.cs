using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PrecioConfiguration : IEntityTypeConfiguration<Precios>
{
    public void Configure(EntityTypeBuilder<Precios> builder)
    {
        builder.Property(precio => precio.Id).ValueGeneratedOnAdd();

        builder.HasKey(precio => new
        {
            precio.Id
        });
    }
}