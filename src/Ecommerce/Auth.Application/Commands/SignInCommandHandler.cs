

using Auth.Application.Services;
using Auth.Domain.Repositories;
using Ecommerce.Abstractions.Messaging;
using Ecommerce.Contracts.Auth.Commands.SignIn;

namespace Auth.Application.Commands
{
    public class SignInCommandHandler : ICommandHandler<SignInCommand, SignInResponse>
    {
        private readonly IAuthUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;

        public SignInCommandHandler(IAuthUserRepository userRepository, 
                                    IPasswordHasher passwordHasher, 
                                    ITokenGenerator tokenGenerator)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<SignInResponse> HandleAsync(SignInCommand command)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email) ??
                throw new Exception("Credencial inválida");

            if(!_passwordHasher.Verify( command.Password, user.PasswordHash))
            {
                throw new Exception("Credencial inválida");
            }

            var token = _tokenGenerator.GenerateToken(user);
            return new SignInResponse(token);

        }
    }
}
