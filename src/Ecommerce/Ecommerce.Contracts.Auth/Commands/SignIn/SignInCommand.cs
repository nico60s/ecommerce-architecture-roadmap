

using Ecommerce.Abstractions.Messaging;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Contracts.Auth.Commands.SignIn
{
    public record SignInCommand : ICommand<SignInResponse>
    {
        [Required]public string Email { get; set; } = string.Empty;
        [Required]public string Password { get; set; } = string.Empty;
        public SignInCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
