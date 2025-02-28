using Library.Domain.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Email)
            .HasMaxLength(User.MAX_EMAIL_LENGTH)
            .IsRequired();
        builder
            .Property(x => x.Name)
            .HasMaxLength(User.MAX_NAME_LENGTH)
            .IsRequired();
        builder
            .Property(x => x.Hash)
            .IsRequired();
        builder
            .Property(x => x.Role)
            .IsRequired();
        builder
            .Property(x => x.Rating)
            .IsRequired();
    }
}