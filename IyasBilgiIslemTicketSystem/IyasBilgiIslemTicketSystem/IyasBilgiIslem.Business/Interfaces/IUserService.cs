using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
