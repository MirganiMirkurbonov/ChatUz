﻿using Domain.Entities.Common;
using Domain.Enums.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

[Table("auth_users", Schema ="auth")]
public class AuthUser : EntityTracked<long>, IHaveHash, ILatLong
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

    [Column("last_online_time")]
    public DateTime LastOnlineTime { get; set; }

    [Column("latitude")]
    public double Latitude { get; set; }

    [Column("longitude")]
    public double Longitude { get; set; }

    [Column("is_online")]
    public bool IsOnline { get; set; }

    [Column("salt")]
    public string? Salt { get; set; }

    [Column("hash")]
    public string? Hash { get; set; }

    [Column("last_otp")]
    public string? LastOtp { get; set; }

    [Column("user_status")]
    public UserStatus UserStatus { get; set; }

    [Column("followers_count")]
    public long FollowersCount { get; set; }

    [Column("friends_count")]
    public long FriendsCount { get; set; }
}
