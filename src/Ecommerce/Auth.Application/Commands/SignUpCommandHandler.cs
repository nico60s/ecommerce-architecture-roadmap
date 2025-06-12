

using Ecommerce.Abstractions.Messaging;

namespace Auth.Application.Commands
{
    internal class SignUpCommandHandler : ICommandHandler<SignUpCommand, Guid>
    {
        public Task<Guid> HandleAsync(SignUpCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
    