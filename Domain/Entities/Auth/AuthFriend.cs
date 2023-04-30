using Domain.Entities.Common;
using Domain.Enums.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

[Table("auth_friends", Schema ="auth")]
public class AuthFriend : EntityTracked<long>
{
    [Column("requested_friend_id")]
    public long RequestedFriendId { get; set; }

    [ForeignKey(nameof(RequestedFriendId))]
    public virtual AuthUser RequestedFriend { get; set; }

    [Column("receiver_friend_id")]
    public long ReceivedFriendId { get; set; }

    [ForeignKey(nameof(ReceivedFriendId))]
    public virtual AuthUser ReceivedFrientId { get; set; }

    [Column("friend_state")]
    public FriendState FriendState{ get; set; }

}
