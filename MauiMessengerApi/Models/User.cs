namespace MauiMessengerApi.Models;

public class User
{
    public int UserId { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public byte[] StoreSalt { get; set; }
    public string AvatarSourceName { get; set; }
    public bool IsOnline { get; set; }
    public DateTime LastLogonTime { get; set; }
}
