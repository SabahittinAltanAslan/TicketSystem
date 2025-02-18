using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Data.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasMany(b => b.Tickets)
                .WithOne(t => t.Branch)
                .HasForeignKey(t => t.BranchId);

            builder.HasMany(b => b.Devices)
                .WithOne(d => d.Branch)
                .HasForeignKey(d => d.BranchId);
        }
    }
}
