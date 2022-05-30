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

        // builder.HasOne(partido => partido.EquipoLocal)
        //         .WithMany(equipo => equipo.PartidosJugados)
        //         .HasForeignKey(partido => partido.IdEquipoLocal);

        // builder.HasOne(partido => partido.EquipoVisitante)
        //         .WithMany(equipo => equipo.PartidosJugados)
        //         .HasForeignKey(partido => partido.IdEquipoVisitante);

        builder.HasOne(partido => partido.Torneo)
                .WithMany(torneo => torneo.Partidos)
                .HasForeignKey(partido => partido.IdTorneo);
    }
}