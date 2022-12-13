namespace MauiMessengerApi.Models.DTOs.Responses;

public class MessageInitializeResponse
{
    public UserDTO FriendInfo { get; set; } = null!;
    public IEnumerable<MessageResponse> Messages { get; set; }
}
