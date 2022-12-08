namespace MauiMessengerApi.Functions.UserFriend;

public class UserFriendService : IUserFriendService
{
    ChatUserContext _chatUserContext;
    IUserFunction _userFunction;     
    
    public UserFriendService(ChatUserContext chatUserContext, IUserFunction userFunction)
    {
        _chatUserContext = chatUserContext;
        _userFunction = userFunction;
    }

    public async Task<IEnumerable<UserDTO>> GetUserFriendsAsync(int userId)
    {
        var userFriends = await _chatUserContext.ChatUserFriends.Where(x => x.UserId == userId).ToListAsync();

        var result = userFriends.Select(x => _userFunction.GetUserById(x.FriendId));

        if (result == null)
            result = new List<UserDTO>();

        return result;
    }
}
