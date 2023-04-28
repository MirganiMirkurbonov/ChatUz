using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

public class Friend : EntityTrackedWithState<long>
{
    [Column("requested_friend_id")]
    public long RequestedFriendId { get; set; }

    [ForeignKey(nameof(RequestedFriendId))]
    public virtual AuthUser RequestedFriend { get; set; }

    [Column("receiver_friend_id")]
    public long ReceivedFriendId { get; set; }

    [ForeignKey(nameof(ReceivedFriendId))]
    public virtual AuthUser ReceivedFrientId { get; set; }

}
