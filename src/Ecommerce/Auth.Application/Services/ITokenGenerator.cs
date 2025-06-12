
using Auth.Domain.Entities;

namespace Auth.Application.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(AuthUser user);
    }
}
