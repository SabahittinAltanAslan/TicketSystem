using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Repositories;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Business.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository<Assignment> _assignmentRepository;
        private readonly UnitOfWork _unitOfWork;

        public AssignmentService(IRepository<Assignment> assignmentRepository, UnitOfWork unitOfWork)
        {
            _assignmentRepository = assignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByTicketIdAsync(int ticketId)
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await _assignmentRepository.AddAsync(assignment);
            await _unitOfWork.CompleteAsync();
        }
    }
}
