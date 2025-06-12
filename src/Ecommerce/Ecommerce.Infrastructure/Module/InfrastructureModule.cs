

using Ecommerce.Abstractions.Hosting;
using Ecommerce.Abstractions.Messaging;
using Ecommerce.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Module
{
    public class InfrastructureModule : IModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICommandDispatcher, InMemoryCommandDispatcher>();

            //Bootstrapping de módulos
            var assemblies = new[]{
                typeof(Auth.Application.AssemblyReference).Assembly 
            };

            services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }
    }
}
