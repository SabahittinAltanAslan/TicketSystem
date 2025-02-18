using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<int>()
                .HasDefaultValue(TicketStatus.Pending)
                .ValueGeneratedNever();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Kullanıcı ilişkisi (Ticket'ı oluşturan kullanıcı)
            builder.HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Kullanıcı ilişkisi (Ticket'a atanmış kullanıcı)
            builder.HasOne(t => t.AssignedUser)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Şube ilişkisi
            builder.HasOne(t => t.Branch)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cihaz ilişkisi
            builder.HasOne(t => t.Device)
                .WithMany(d => d.Tickets)
                .HasForeignKey(t => t.DeviceId)
                .OnDelete(DeleteBehavior.SetNull);

            // Kategori ilişkisi
            builder.HasOne(t => t.Category)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CategoryId);
        }
    }
}
