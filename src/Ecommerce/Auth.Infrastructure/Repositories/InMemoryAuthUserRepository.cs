
using Auth.Domain.Entities;
using Auth.Domain.Repositories;

namespace Auth.Infrastructure.Repositories
{
    internal class InMemoryAuthUserRepository : IAuthUserRepository
    {
        private readonly List<AuthUser> _users = [];
        public async Task Add(AuthUser user)
        {
            _users.Add(user);
        }

        public async Task<bool> ExistEmailAsync(string email)
        {
            bool exist = false;
            if (_users.Any(u => u.Email == email))
                exist= true;
            else 
                exist =  false;

            return exist;
        }

        public async Task<AuthUser> GetByEmailAsync(string email)
        {
            return  _users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
