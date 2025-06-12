
using Auth.Domain.Entities;
using Auth.Domain.Repositories;

namespace Auth.Infrastructure.Repositories
{
    internal class InMemoryAuthUserRepository : IAuthUserRepository
    {
        public Task Add(AuthUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AuthUser> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
