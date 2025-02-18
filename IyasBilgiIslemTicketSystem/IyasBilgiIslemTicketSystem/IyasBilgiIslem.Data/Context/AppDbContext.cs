using Microsoft.EntityFrameworkCore;
using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StatusLog> StatusLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
