

using System.Security.Claims;

namespace Ecommerce.Contracts.Auth.Services
{
    public interface ITokenValidator
    {
        ClaimsPrincipal? Validate(string token);
    }
}
