

using Ecommerce.Contracts.Auth.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Infrastructure
{
    public class JwtValidatorService : ITokenValidator
    {
        private readonly string _secret;
        public JwtValidatorService(IConfiguration configuration)
        {
            _secret = configuration["Jwt:Secret"] ?? throw new ArgumentNullException(nameof(configuration));
        }
        public ClaimsPrincipal? Validate(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secret);
            var parameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            };

            try
            {
                var principal = handler.ValidateToken(token, parameters, out _);
                return principal;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
