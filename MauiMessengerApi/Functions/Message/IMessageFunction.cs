namespace MauiMessengerApi.Functions.Message;

public interface IMessageFunction
{
    Task<IEnumerable<LastestMessage>> GetLastestMessage(int userId);

    Task<IEnumerable<MessageResponse>> GetMessages(int fromUserId, int toUserId);

    Task<int> AddMessage(int fromUserId, int toUserId, string message);
}
