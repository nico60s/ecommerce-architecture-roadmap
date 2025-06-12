

using Auth.Application.Services;
using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using Contracts.Auth.Commands;
using Ecommerce.Abstractions.Messaging;

namespace Auth.Application.Commands
{
    public class SignUpCommandHandler : ICommandHandler<SignUpCommand, Guid>
    {
        private readonly IAuthUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public SignUpCommandHandler(IAuthUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<Guid> HandleAsync(SignUpCommand command)
        {
            if (await _userRepository.ExistEmailAsync(command.Email))
                throw new InvalidOperationException("El email ya está registrado.");

            var passwordHash = _passwordHasher.Hash(command.Password);
            var id = Guid.NewGuid();
            var email = command.Email;
            var user = new AuthUser(id, email, passwordHash);

            await _userRepository.Add(user);
            return user.Id;
        }
    }
}
    