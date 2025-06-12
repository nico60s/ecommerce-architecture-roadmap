

using Auth.Application.Services;
using Auth.Domain.Repositories;
using Auth.Infrastructure.Repositories;
using Ecommerce.Abstractions.Hosting;
using Ecommerce.Contracts.Auth.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Module
{
    public class AuthModule : IModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenValidator, JwtValidatorService>();
            services.AddScoped<IAuthUserRepository, InMemoryAuthUserRepository>();

        }
    }
}
