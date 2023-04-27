using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

public class AuthRole : Entity<long>
{
    [Column("description")]
    public string Description { get; set; }

    [Column("keyword")]
    public string Keyword { get; set; }
}
