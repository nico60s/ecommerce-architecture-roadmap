namespace Auth.Domain.Entities
{
    public class AuthUser
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string PasswordHash { get; init; }

        public AuthUser(Guid id, string email, string passwordHash)
        {
            Id = id;
            Email = email;
            PasswordHash = passwordHash;               
        }
    }
}
