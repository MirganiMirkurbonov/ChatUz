using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Auth;
using Domain.Entities.Common;
using Domain.Enums.Status;

namespace Domain.Entities.Location;

public class UserLocation : EntityTracked<long>, ILatLong
{
    [Column("latitude")]
    public double Latitude { get; set; }

    [Column("longitude")]
    public double Longitude { get; set; }

    [Column("location_status")]
    public LocationStatus LocationStatus { get; set; }

    [Column("auth_user_id")]
    public long AuthUserId { get; set; }

    [ForeignKey(nameof(AuthUserId))]
    public virtual AuthUser AuthUser { get; set; }
}