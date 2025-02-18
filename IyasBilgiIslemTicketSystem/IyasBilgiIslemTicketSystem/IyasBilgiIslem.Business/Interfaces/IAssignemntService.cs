using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> GetAssignmentsByTicketIdAsync(int ticketId);
        Task AddAssignmentAsync(Assignment assignment);
    }
}
