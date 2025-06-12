﻿

namespace Ecommerce.Abstractions.Messaging
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
    public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse> 
    {
        Task<TResponse> HandleAsync(TCommand command);
    }
}
