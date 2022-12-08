namespace MauiMessengerApi.Functions.UserFriend;

public interface IUserFriendService
{
    Task<IEnumerable<UserDTO>> GetUserFriendsAsync(int userId);
}
