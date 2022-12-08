namespace MauiMessengerApi.Models;

public class ChatUserFriend
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FriendId { get; set; }
}
