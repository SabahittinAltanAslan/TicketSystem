using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Repositories;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;

namespace IyasBilgiIslem.Business.Services
{
    public class StatusLogService : IStatusLogService
    {
        private readonly IStatusLogRepository _statusLogRepository;

        public StatusLogService(IStatusLogRepository statusLogRepository)
        {
            _statusLogRepository = statusLogRepository;
        }

        public async Task<IEnumerable<StatusLog>> GetLogsByTicketIdAsync(int ticketId)
        {
            return await _statusLogRepository.GetLogsByTicketIdAsync(ticketId);
        }
    }
}
