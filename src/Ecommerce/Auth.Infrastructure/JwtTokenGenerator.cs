

using Auth.Application.Services;
using Auth.Domain.Entities;

namespace Auth.Infrastructure
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        public string GenerateToken(AuthUser user)
        {
            var someJwtFake = "JWT";
            return someJwtFake;
        }
    }
}
