using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
{
    public void Configure(EntityTypeBuilder<Equipo> builder)
    {
        builder.Property(equipo => equipo.Id).ValueGeneratedOnAdd();

        builder.HasKey(equipo => new
        {
            equipo.Id
        });

        builder
                .Property(equipo => equipo.Nombre)
                .HasColumnType("nvarchar(70)")
                .IsRequired();

        builder.HasMany(equipo => equipo.Jugadores)
                .WithOne(c => c.Equipo)
                .HasForeignKey(equipo => equipo.Id);
    }
}