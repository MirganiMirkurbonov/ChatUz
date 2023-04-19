using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Common;

internal class EntityTrackedWithState<Tid> : Entity<Tid>
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("state")]
    public State State{ get; set; }
}
