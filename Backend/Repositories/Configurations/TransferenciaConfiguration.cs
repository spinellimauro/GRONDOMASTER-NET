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
                .HasForeignKey(trans => trans.IdDTComprador);

        builder.HasOne(trans => trans.DtVendedor)
                .WithMany(c => c.Compras)
                .HasForeignKey(trans => trans.IdDTVendedor);
    }
}