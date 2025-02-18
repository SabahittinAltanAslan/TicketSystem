using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Data.Configurations
{
    public class StatusLogConfiguration : IEntityTypeConfiguration<StatusLog>
    {
        public void Configure(EntityTypeBuilder<StatusLog> builder)
        {
            builder.HasOne(s => s.Ticket)
                .WithMany(t => t.StatusLogs)
                .HasForeignKey(s => s.TicketId)
                .OnDelete(DeleteBehavior.Cascade); // Ticket silindiğinde geçmişi de silinir.

            builder.HasOne(s => s.ChangedByUser)
                .WithMany()
                .HasForeignKey(s => s.ChangedByUserId)
                .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silindiğinde StatusLog kaydı kalır.
        }
    }
}
