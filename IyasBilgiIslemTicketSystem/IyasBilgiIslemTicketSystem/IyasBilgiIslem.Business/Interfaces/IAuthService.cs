using IyasBilgiIslem.Core.Entities;

namespace IyasBilgiIslem.Business.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string email, string password);
    }
}
