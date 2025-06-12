using Auth.Application.Services;

namespace Auth.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        public bool Verify(string plainTextPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
        }
    }
}
