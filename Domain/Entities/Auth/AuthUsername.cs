using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

public class AuthUsername : Entity<long>
{
    [Column("username")]
    public string Username { get; set; }
}
