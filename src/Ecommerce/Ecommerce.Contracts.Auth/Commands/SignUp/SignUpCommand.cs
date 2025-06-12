using Ecommerce.Abstractions.Messaging;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Contracts.Auth.Commands.SignUp
{
    public record SignUpCommand : ICommand<Guid>
    {
        [Required]public string Email { get; set; } = string.Empty;

        [Required]public string Password { get; set; } = string.Empty;
        public SignUpCommand(string email, string passwod)
        {
            Email = email;
            Password = passwod;
        }
    }
}
