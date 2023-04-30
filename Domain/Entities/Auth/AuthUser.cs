using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

public class AuthUser : EntityTracked<long>
{
    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("username_id")]
    public long? UsernameId { get; set; }

    [ForeignKey(nameof(UsernameId))]
    public virtual AuthUsername? Username { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("role_id")]
    public long? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual AuthRole? AuthRole { get; set; }

    [Column("last_online_time")]
    public DateTime LastOnlineTime { get; set; }

    [Column("latitude")]
    public double Latitude { get; set; }

    [Column("longitude")]
    public double Longitude { get; set; }

    [Column("is_online")]
    public bool IsOnline { get; set; }
}
