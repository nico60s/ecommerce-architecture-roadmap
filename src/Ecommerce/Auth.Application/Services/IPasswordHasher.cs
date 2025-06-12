

namespace Auth.Application.Services
{
    public interface IPasswordHasher
    {
        string Hash(string plainTextPassword);
        bool Verify(string hashedPassword, string plainTextPassword);
    }
}
