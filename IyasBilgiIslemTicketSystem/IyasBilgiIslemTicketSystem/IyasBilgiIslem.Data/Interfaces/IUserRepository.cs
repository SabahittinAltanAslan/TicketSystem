using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
