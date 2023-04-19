using Domain.Entities.Common;

namespace Domain.Entities.Auth;

public class AuthUser : EntityTrackedWithState<long>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; }
}
