
using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Abstractions.Messaging;

namespace Ecommerce.Infrastructure.Messaging
{
    public class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private  IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command);
        }

        public async Task<TResponse> DispatchAsync<TCommand, TResponse>(TCommand command) where TCommand : ICommand<TResponse>
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
            return await handler.HandleAsync(command);
        }
    }
}
