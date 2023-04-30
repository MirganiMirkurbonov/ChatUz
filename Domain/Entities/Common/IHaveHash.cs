using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Common;

public interface IHaveHash
{
    [Column("salt")]
    public string? Salt { get; set; }

    [Column("hash")]
    public string? Hash { get; set; }
}
