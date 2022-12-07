namespace MauiMessengerApi.Models;

public class ChatUser
{
    [Key]
    public int UserId { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public byte[] StoredSalt { get; set; }
    public string AvatarSourceName { get; set; }
    public bool IsOnline { get; set; }
    public DateTime LastLogonTime { get; set; }
}
