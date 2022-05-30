using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TorneoEquipoConfiguration : IEntityTypeConfiguration<TorneoEquipo>
{
    public void Configure(EntityTypeBuilder<TorneoEquipo> builder)
    {
        builder.Property(torneoEquipo => torneoEquipo.Id).ValueGeneratedOnAdd();

        builder.HasKey(torneoEquipo => new
        {
            torneoEquipo.Id
        });

        builder.HasOne(torneoEquipo => torneoEquipo.Torneo)
                .WithMany(torneo => torneo.TorneosEquipos)
                .HasForeignKey(torneoEquipo => new { torneoEquipo.IdTorneo })
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(torneoEquipo => torneoEquipo.Equipo)
                .WithMany(equipo => equipo.TorneosEquipos)
                .HasForeignKey(torneoEquipo => new { torneoEquipo.IdEquipo })
                .OnDelete(DeleteBehavior.Restrict);
    }
}