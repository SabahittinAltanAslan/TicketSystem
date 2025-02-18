using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(TicketStatus status);
        Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId);
        Task<IEnumerable<Ticket>> GetTicketsByAssignedRoleAsync(string assignedRole); // Yeni eklenen metod
    }
}
