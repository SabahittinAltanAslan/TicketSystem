using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces
{
    public interface IStatusLogService
    {
        Task<IEnumerable<StatusLog>> GetLogsByTicketIdAsync(int ticketId);
    }
}
