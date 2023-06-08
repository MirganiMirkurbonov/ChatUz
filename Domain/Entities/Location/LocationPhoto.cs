using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities.Location;

public class LocationPhoto : EntityTracked<long>
{
    [Column("url")]
    public string Url { get; set; }

    [Column("extension")]
    public string Extension { get; set; }

    [Column("size")]
    public double Size  { get; set; }

    [Column("location_id")]
    public long LocationId { get; set; }

    [ForeignKey(nameof(LocationId))]
    public virtual UserLocation UserLocation{ get; set; }
}