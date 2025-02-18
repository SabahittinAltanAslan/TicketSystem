using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device> GetDeviceByIdAsync(int id);
        Task<IEnumerable<Device>> GetDevicesByBranchAsync(int branchId);
        Task AddDeviceAsync(Device device);
        Task UpdateDeviceAsync(Device device);
    }
}
