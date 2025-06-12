
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Abstractions.Hosting
{
    public interface IModule
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
