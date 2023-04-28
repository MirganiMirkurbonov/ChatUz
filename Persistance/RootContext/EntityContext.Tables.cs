using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Persistance.RootContext;

public partial class EntityContext
{
    public virtual DbSet<AuthUser> AuthUsers { get; set; }
    public virtual DbSet<AuthUsername> AuthUsernames { get; set; }
    public virtual DbSet<AuthRole> AuthRoles { get; set; }
    public virtual DbSet<Friend> Friends { get; set; }
}
