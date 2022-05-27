using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PremioEventoConfiguration : IEntityTypeConfiguration<PremioEvento>
{
    public void Configure(EntityTypeBuilder<PremioEvento> builder)
    {
        builder.Property(premioEvento => premioEvento.Id).ValueGeneratedOnAdd();

        builder.HasKey(premioEvento => new
        {
            premioEvento.Id
        });

        builder
                .Property(premioEvento => premioEvento.NombreEvento)
                .HasColumnType("nvarchar(30)")
                .IsRequired();
    }
}