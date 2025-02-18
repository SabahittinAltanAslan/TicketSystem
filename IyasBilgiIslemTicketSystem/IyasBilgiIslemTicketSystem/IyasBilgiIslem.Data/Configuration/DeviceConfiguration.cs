using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Data.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.SerialNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Manufacturer)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(d => d.Branch)
                .WithMany(b => b.Devices)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.AssignedTo)
                .WithMany(u => u.Devices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
