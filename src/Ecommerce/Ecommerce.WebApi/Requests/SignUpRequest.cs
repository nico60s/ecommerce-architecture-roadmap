using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Requests
{
    public record SignUpRequest
    {
        [Required]public string Email { get; set; } = string.Empty;
        [Required]public string Password { get; set; } = string.Empty;

        public SignUpRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
