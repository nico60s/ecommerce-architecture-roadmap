

namespace Ecommerce.Abstractions.Messaging
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command)
        where TCommand : ICommand;

        Task<TResponse> DispatchAsync<TCommand, TResponse>(TCommand command)
            where TCommand : ICommand<TResponse>;
    }
}
