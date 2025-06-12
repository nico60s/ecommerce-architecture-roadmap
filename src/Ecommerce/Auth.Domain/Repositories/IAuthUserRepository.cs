using Auth.Domain.Entities;

namespace Auth.Domain.Repositories
{
    public interface IAuthUserRepository
    {
        Task<bool> ExistEmailAsync(string email);
        Task Add(AuthUser user);
    }
}
