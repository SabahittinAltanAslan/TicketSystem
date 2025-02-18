using Microsoft.EntityFrameworkCore;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Context;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Data.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Device>> GetDevicesByBranchAsync(int branchId)
        {
            return await _context.Devices.Where(d => d.BranchId == branchId).ToListAsync();
        }
    }
}
