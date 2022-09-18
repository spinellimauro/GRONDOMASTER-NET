using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EquipoSofifaConfiguration : IEntityTypeConfiguration<EquipoSofifa>
{
    public void Configure(EntityTypeBuilder<EquipoSofifa> builder)
    {
        builder.Property(sofifa => sofifa.Id).ValueGeneratedOnAdd();

        builder.HasKey(sofifa => new
        {
            sofifa.Id
        });

        builder
                .Property(equipoSoFifa => equipoSoFifa.Nombre)
                .HasColumnType("nvarchar(70)")
                .IsRequired();

         builder
                .Property(equipoSoFifa => equipoSoFifa.UrlImage)
                .HasColumnType("nvarchar(60)")
                .IsRequired();
    }
}