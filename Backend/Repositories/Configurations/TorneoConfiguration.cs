using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TorneoConfiguration : IEntityTypeConfiguration<Torneo>
{
    public void Configure(EntityTypeBuilder<Torneo> builder)
    {
        builder.Property(torneo => torneo.Id).ValueGeneratedOnAdd();

        builder.HasKey(torneo => new
        {
            torneo.Id
        });

        builder
                .Property(torneo => torneo.Nombre)
                .HasColumnType("nvarchar(40)")
                .IsRequired();
    }
}