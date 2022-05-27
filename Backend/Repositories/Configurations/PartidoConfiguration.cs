using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PartidoConfiguration : IEntityTypeConfiguration<Partido>
{
    public void Configure(EntityTypeBuilder<Partido> builder)
    {
        builder.Property(partido => partido.Id).ValueGeneratedOnAdd();

        builder.HasKey(partido => new
        {
            partido.Id
        });

        builder.HasOne(partido => partido.EquipoLocal)
                .WithMany(c => c.PartidosJugados)
                .HasForeignKey(partido => partido.IdEquipoLocal);

        builder.HasOne(partido => partido.EquipoVisitante)
                .WithMany(c => c.PartidosJugados)
                .HasForeignKey(partido => partido.IdEquipoVisitante);
    }
}