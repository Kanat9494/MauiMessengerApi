namespace MauiMessengerApi.Models;

public class Message
{
    [Key]
    public int MessageId { get; set; }
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime SentDateTime { get; set;  }
    public bool IsRead { get; set; }
}
