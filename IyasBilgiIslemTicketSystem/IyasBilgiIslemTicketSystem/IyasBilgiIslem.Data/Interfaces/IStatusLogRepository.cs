using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Data.Repositories
{
    public interface IStatusLogRepository : IRepository<StatusLog>
    {
        Task<IEnumerable<StatusLog>> GetLogsByTicketIdAsync(int ticketId);
    }
}
