using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Task<IEnumerable<Device>> GetDevicesByBranchAsync(int branchId);
    }
}
