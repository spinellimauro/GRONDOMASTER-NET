using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MercadoConfiguration : IEntityTypeConfiguration<Mercado>
{
    public void Configure(EntityTypeBuilder<Mercado> builder)
    {
        builder.Property(mercado => mercado.Id).ValueGeneratedOnAdd();

        builder.HasKey(mercado => new
        {
            mercado.Id
        });

        builder.HasMany(mercado => mercado.listaOfertas)
                .WithOne(c => c.Mercado)
                .HasForeignKey(oferta => oferta.IdMercado);

        builder.HasMany(mercado => mercado.listaTransferencias)
                .WithOne(c => c.Mercado)
                .HasForeignKey(transferencia => transferencia.IdMercado);
    }
}