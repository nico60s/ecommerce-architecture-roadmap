using Auth.Application.Services;

namespace Auth.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        public bool Verify(string hashedPassword, string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.Verify(hashedPassword,plainTextPassword);
        }
    }
}
