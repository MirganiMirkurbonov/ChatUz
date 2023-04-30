using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

[Table("auth_usernames", Schema ="auth")]
public class AuthUsername : Entity<long>
{
    [Column("username")]
    public string Username { get; set; }
}
