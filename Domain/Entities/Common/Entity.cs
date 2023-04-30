using Domain.Enums;
using Domain.Enums.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Common;

public class Entity<T>
{
    [Column("id")]
    public T Id { get; set; }

    [Column("state")]
    public State State { get; set; }
}
