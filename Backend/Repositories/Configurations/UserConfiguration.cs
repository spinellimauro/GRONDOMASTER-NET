using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // builder.Property(user => user.Id).ValueGeneratedOnAdd();

        // builder.HasKey(user => new
        // {
        //     user.Id
        // });

        builder.HasOne(u => u.Usuario)
                .WithOne(dt => dt.User)
                .HasForeignKey<DT>(u => u.UserId);
    }
}