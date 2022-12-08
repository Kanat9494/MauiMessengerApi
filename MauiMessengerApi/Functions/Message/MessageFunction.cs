namespace MauiMessengerApi.Functions.Message;

public class MessageFunction : IMessageFunction
{
    ChatUserContext _chatUserContext;
    IUserFunction _userFunction;

    public MessageFunction(ChatUserContext chatUserContext, IUserFunction userFunction)
    {
        _chatUserContext = chatUserContext;
        _userFunction = userFunction;
    }

    public async Task<IEnumerable<LastestMessage>> GetLastestMessage(int userId)
    {
        var result = new List<LastestMessage>();

        var userFriends = await _chatUserContext.ChatUserFriends.Where(x => x.UserId == userId).ToListAsync();

        foreach (var userFriend in userFriends)
        {
            var lastMessage = await _chatUserContext.Messages.Where(x => 
            (x.FromUserId == userId && x.ToUserId == userFriend.FriendId) ||
            (x.FromUserId == userFriend.FriendId && x.ToUserId == userId))
                .OrderByDescending(x => x.SentDateTime).FirstOrDefaultAsync();

            if (lastMessage != null)
            {
                result.Add(new LastestMessage
                {
                    UserId = userId,
                    Content = lastMessage.Content,
                    UserFriendInfo = _userFunction.GetUserById(userFriend.FriendId),
                    Id = lastMessage.MessageId,
                    IsRead = lastMessage.IsRead,
                    SentDateTime = lastMessage.SentDateTime,
                });
            }
        }

        return result;
    }
}
