using IyasBilgiIslem.Data.Context;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context;

        public ITicketRepository Tickets { get; }
        public IUserRepository Users { get; }
        public IDeviceRepository Devices { get; }
        public IStatusLogRepository StatusLogs { get; }

        public UnitOfWork(
            AppDbContext context,
            ITicketRepository tickets,
            IUserRepository users,
            IDeviceRepository devices,
            IStatusLogRepository statusLogs)
        {
            _context = context;
            Tickets = tickets;
            Users = users;
            Devices = devices;
            StatusLogs = statusLogs;
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
