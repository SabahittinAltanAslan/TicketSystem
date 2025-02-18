using Microsoft.EntityFrameworkCore;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Context;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Data.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(TicketStatus status)
        {
            return await _context.Tickets.Where(t => t.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId)
        {
            return await _context.Tickets
                .Where(t => t.CreatedByUserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByAssignedRoleAsync(string assignedRole)
        {
            return await _context.Tickets
                .Where(t => t.AssignedRole == assignedRole)
                .ToListAsync();
        }

    }
}
