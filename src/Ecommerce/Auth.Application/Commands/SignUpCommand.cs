

using Ecommerce.Abstractions.Messaging;
using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Commands
{
    public record SignUpCommand : ICommand<Guid>
    {
        [Required]string Email { get; set; } = string.Empty;

        [Required] string Password { get; set; } = string.Empty;
    }
}
