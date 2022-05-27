using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JugadorConfiguration : IEntityTypeConfiguration<Jugador>
{
    public void Configure(EntityTypeBuilder<Jugador> builder)
    {
        builder.Property(jugador => jugador.Id).ValueGeneratedOnAdd();

        builder.HasKey(jugador => new
        {
            jugador.Id
        });

        builder
                .Property(contact => contact.Nombre)
                .HasColumnType("nvarchar(70)")
                .IsRequired();

        builder.Property(contact => contact.Nacionalidad)
                .HasColumnType("nvarchar(70)")
                .IsRequired();

        builder.Property(contact => contact.NacionalidadCorta)
                .HasColumnType("nvarchar(30)")
                .IsRequired();

        builder.Property(contact => contact.Posiciones)
                .HasColumnType("nvarchar(30)")
                .IsRequired();

        builder.HasOne(jugador => jugador.Equipo)
                .WithMany(e => e.Jugadores)
                .HasForeignKey(jugador => jugador.IdEquipo);
    }
}