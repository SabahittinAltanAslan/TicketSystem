using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Data.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasOne(a => a.Ticket)
                .WithMany(t => t.Assignments)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.Cascade); // Ticket silinirse, atamalar da silinir.

            builder.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silindiğinde atamalar kalır.
        }
    }
}
