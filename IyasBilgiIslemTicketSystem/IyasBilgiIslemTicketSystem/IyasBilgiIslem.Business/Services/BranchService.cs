using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Repositories;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Business.Services
{
    public class BranchService : IBranchService
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly UnitOfWork _unitOfWork;

        public BranchService(IRepository<Branch> branchRepository, UnitOfWork unitOfWork)
        {
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            return await _branchRepository.GetAllAsync();
        }

        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            return await _branchRepository.GetByIdAsync(id);
        }

        public async Task AddBranchAsync(Branch branch)
        {
            await _branchRepository.AddAsync(branch);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateBranchAsync(Branch branch)
        {
            _branchRepository.Update(branch);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteBranchAsync(Branch branch) 
        {
            _branchRepository.Delete(branch);
            await _unitOfWork.CompleteAsync();
        }
    }
}
