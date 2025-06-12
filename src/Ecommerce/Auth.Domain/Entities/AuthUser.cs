namespace Auth.Domain.Entities
{
    public class AuthUser
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string PasswordHash { get; init; }

        public AuthUser(Guid id, string name, string passwordHash)
        {
            Id = id;
            Name = name;
            PasswordHash = passwordHash;               
        }
    }
}
