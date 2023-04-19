using Domain.Entities.Common;

namespace Domain.Entities.Auth;

public class AuthUsername : Entity<long>
{
    public string Username { get; set; }
}
