using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Common;

public interface ILatLong
{
    [Column("latitude")]
    public double Latitude { get; set; }

    [Column("longitude")]
    public double Longitude { get; set; }
}
