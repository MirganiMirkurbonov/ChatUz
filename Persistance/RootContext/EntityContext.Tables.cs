using Domain.Entities.Auth;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;

namespace Persistance.RootContext;

public partial class EntityContext
{
    #region auth
    public virtual DbSet<AuthUser> AuthUsers { get; set; }
    public virtual DbSet<AuthUsername> AuthUsernames { get; set; }
    public virtual DbSet<AuthRole> AuthRoles { get; set; }
    public virtual DbSet<AuthFriend> Friends { get; set; }
    #endregion


    #region Location
    public virtual DbSet<LocationPhoto> LocationPhotos { get; set; }
    public virtual DbSet<UserLocation> UserLocations { get; set; }
    #endregion
}
