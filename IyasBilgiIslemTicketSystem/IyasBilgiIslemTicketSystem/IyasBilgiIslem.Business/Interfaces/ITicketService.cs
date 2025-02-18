using IyasBilgiIslem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IyasBilgiIslem.Business.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId);
        Task<IEnumerable<Ticket>> GetTicketsByAssignedRoleAsync(string assignedRole);
        Task AddTicketAsync(Ticket ticket);
        Task UpdateTicketStatusAsync(int ticketId, TicketStatus newStatus, int userId);
    }
}
