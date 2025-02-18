using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> GetAllBranchesAsync();
        Task<Branch> GetBranchByIdAsync(int id);
        Task AddBranchAsync(Branch branch);
        Task UpdateBranchAsync(Branch branch);
        Task DeleteBranchAsync(Branch branch); 
    }
}
