﻿using Domain.Entities.Common;
using Domain.Enums.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

[Table("auth_users", Schema ="auth")]
public class AuthUser : EntityTracked<long>, IHaveHash
{
    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("bio")]
    public string? Bio { get; set; }

    [Column("username_id")]
    public long? UsernameId { get; set; }

    [ForeignKey(nameof(UsernameId))]
    public virtual AuthUsername? Username { get; set; }

    [Column("email_hash")]
    public string? EmailHash { get; set; }

    [Column("phone_hash")]
    public string? PhoneHash { get; set; }

    [Column("salt")]
    public string? Salt { get; set; }

    [Column("hash")]
    public string? Hash { get; set; }

    [Column("last_otp")]
    public string? LastOtpHash { get; set; }

    [Column("user_status")]
    public UserStatus UserStatus { get; set; }

    [Column("location_visible_for")]
    public LocationVisibleFor LocationVisibleFor { get; set; }

    [Column("friends_count")]
    public long FriendsCount { get; set; }
}
