using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SucesoConfiguration : IEntityTypeConfiguration<Suceso>
{
    public void Configure(EntityTypeBuilder<Suceso> builder)
    {
        builder.Property(suceso => suceso.Id).ValueGeneratedOnAdd();

        builder.HasKey(suceso => new
        {
            suceso.Id
        });

        builder.HasOne(suceso => suceso.Jugador)
                .WithMany(jugador => jugador.Sucesos)
                .HasForeignKey(suceso => suceso.IdJugador);

        builder.HasOne(suceso => suceso.Partido)
                .WithMany(partido => partido.Sucesos)
                .HasForeignKey(suceso => suceso.IdPartido);
    }
}