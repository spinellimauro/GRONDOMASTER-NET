using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransferenciaConfiguration : IEntityTypeConfiguration<Transferencia>
{
    public void Configure(EntityTypeBuilder<Transferencia> builder)
    {
        builder.Property(trans => trans.Id).ValueGeneratedOnAdd();

        builder.HasKey(trans => new
        {
            trans.Id
        });

        builder.HasOne(trans => trans.DtComprador)
                .WithMany(c => c.Compras)
                .HasForeignKey(trans => trans.IdDTComprador)
                .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(trans => trans.DtVendedor)
                .WithMany(c => c.Ventas)
                .HasForeignKey(trans => trans.IdDTVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(trans => trans.Jugador)
                .WithMany(c => c.Transferencias)
                .HasForeignKey(trans => trans.IdJugador);
    }
}