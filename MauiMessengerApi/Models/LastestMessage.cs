namespace MauiMessengerApi.Models;

public class LastestMessage
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserDTO UserFriendInfo { get; set; }
    public string Content { get; set; } = null!;
    public DateTime SentDateTime { get; set; }
    public bool IsRead { get; set; }
}
