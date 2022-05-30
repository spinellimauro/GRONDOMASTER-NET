using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OfertaJugadorConfiguration : IEntityTypeConfiguration<OfertaJugador>
{
    public void Configure(EntityTypeBuilder<OfertaJugador> builder)
    {
        builder.Property(oferta => oferta.Id).ValueGeneratedOnAdd();

        builder.HasKey(oferta => new
        {
            oferta.Id
        });

        builder.HasOne(oferta => oferta.Jugador)
                .WithMany(jugador => jugador.OfertasJugador)
                .HasForeignKey(oferta => new { oferta.IdJugador })
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(oferta => oferta.Oferta)
                .WithMany(jugador => jugador.OfertasJugador)
                .HasForeignKey(oferta => new { oferta.IdOferta })
                .OnDelete(DeleteBehavior.Cascade);
    }
}