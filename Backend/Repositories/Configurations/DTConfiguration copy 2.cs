using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DTConfiguration : IEntityTypeConfiguration<DT>
{
    public void Configure(EntityTypeBuilder<DT> builder)
    {
        builder.Property(usuario => usuario.Id).ValueGeneratedOnAdd();

        builder.HasKey(usuario => new
        {
            usuario.Id
        });

        builder
                .Property(contact => contact.Nombre)
                .HasColumnType("nvarchar(70)")
                .IsRequired();

        builder.Property(contact => contact.Apellido)
                .HasColumnType("nvarchar(70)")
                .IsRequired();

        builder.HasOne(usuario => usuario.Equipo)
                .WithOne(c => c.DT)
                .HasForeignKey<Equipo>(equipo => equipo.UserId);
    }
}