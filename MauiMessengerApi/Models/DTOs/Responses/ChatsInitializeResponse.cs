namespace MauiMessengerApi.Models.DTOs.Responses;

public class ChatsInitializeResponse
{
    public UserDTO User { get; set; } = null!;
    public IEnumerable<UserDTO> UserFriends { get; set; } = null!;
    public IEnumerable<LastestMessage> LastestMessages { get; set; } = null!; 
}
