namespace MauiMessengerApi.Models.DTOs.Responses;

public class MessageResponse
{
    public int MessageId { get; set; }
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public string Content { get; set; }
    public DateTime SentDateTime { get; set; }
    public bool IsRead { get; set; }
}
