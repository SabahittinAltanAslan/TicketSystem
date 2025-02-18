using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.Role).IsRequired().HasConversion<int>();

            builder.HasIndex(u => u.Email).IsUnique();

            // Kullanıcının oluşturduğu ticket'lar
            builder.HasMany(u => u.CreatedTickets)
                .WithOne(t => t.CreatedByUser)
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Kullanıcıya atanmış ticket'lar
            builder.HasMany(u => u.AssignedTickets)
                .WithOne(t => t.AssignedUser)
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Kullanıcının zimmetli cihazları
            builder.HasMany(u => u.Devices)
                .WithOne(d => d.AssignedTo)
                .HasForeignKey(d => d.UserId);
        }
    }
}
