using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Contracts.Auth.Commands.SignIn
{
    public record SignInResponse
    {
        [Required]public string TokenDto { get; private set; }
        public SignInResponse(string tokenDto)
        {
            TokenDto = tokenDto;
        }
    }
}
