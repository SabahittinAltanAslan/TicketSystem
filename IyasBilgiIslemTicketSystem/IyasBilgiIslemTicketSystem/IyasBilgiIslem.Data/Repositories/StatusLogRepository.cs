using Microsoft.EntityFrameworkCore;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Context;

namespace IyasBilgiIslem.Data.Repositories
{
    public class StatusLogRepository : GenericRepository<StatusLog>, IStatusLogRepository
    {
        private readonly AppDbContext _context;

        public StatusLogRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StatusLog>> GetLogsByTicketIdAsync(int ticketId)
        {
            return await _context.StatusLogs
                .Where(log => log.TicketId == ticketId)
                .OrderByDescending(log => log.ChangedAt)
                .ToListAsync();
        }
    }
}
