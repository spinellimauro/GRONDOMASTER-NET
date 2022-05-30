using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OfertaConfiguration : IEntityTypeConfiguration<Oferta>
{
    public void Configure(EntityTypeBuilder<Oferta> builder)
    {
        builder.Property(oferta => oferta.Id).ValueGeneratedOnAdd();

        builder.HasKey(oferta => new
        {
            oferta.Id
        });

        builder.HasOne(oferta => oferta.DtOfertante)
                .WithMany(dt => dt.OfertasRealizadas)
                .HasForeignKey(oferta => oferta.IdDtOfertante)
                .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(oferta => oferta.DtReceptor)
                .WithMany(dt => dt.OfertasRecibidas)
                .HasForeignKey(oferta => oferta.IdDtReceptor)
                .OnDelete(DeleteBehavior.ClientSetNull);

        // builder.HasOne(oferta => oferta.JugadorOfertado)
        //         .WithMany(jugador => jugador.OfertasRecibidas)
        //         .HasForeignKey(oferta => oferta.IdJugadorOfertado)
        //         .OnDelete(DeleteBehavior.ClientSetNull);
    }
}