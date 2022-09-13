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

        builder
                .Property(equipo => equipo.ManagerId)
                .HasColumnType("int");

        builder.HasMany(equipo => equipo.Jugadores)
                .WithOne(jugador => jugador.Equipo)
                .HasForeignKey(equipo => equipo.Id);

        builder.HasMany(equipo => equipo.PartidosJugadosLocal)
                .WithOne(partido => partido.EquipoLocal)
                .HasForeignKey(equipo => equipo.IdEquipoLocal)
                .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasMany(equipo => equipo.PartidosJugadosVisitante)
                .WithOne(partido => partido.EquipoVisitante)
                .HasForeignKey(equipo => equipo.IdEquipoVisitante)
                .OnDelete(DeleteBehavior.ClientSetNull);
    }
}