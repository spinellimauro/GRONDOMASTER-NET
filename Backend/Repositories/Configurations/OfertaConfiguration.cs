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
                .HasForeignKey(oferta => oferta.IdDtOfertante);

        builder.HasOne(oferta => oferta.DtReceptor)
                .WithMany(dt => dt.OfertasRecibidas)
                .HasForeignKey(oferta => oferta.IdDtReceptor);

        builder.HasOne(oferta => oferta.JugadorOfertado)
                .WithMany(jugador => jugador.OfertasRecibidas)
                .HasForeignKey(oferta => oferta.IdJugadorOfertado);

        builder.HasMany(oferta => oferta.JugadoresOfrecidos)
                .WithMany(jugador => jugador.OfertasOfrecido)
                .UsingEntity(j => j.ToTable("OfertaJugador"));
    }
}