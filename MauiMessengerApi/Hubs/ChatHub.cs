namespace MauiMessengerApi.Hubs;

public class ChatHub : Hub
{
    UserOperator _userOperator;
    IMessageFunction _messageFunction;  
    private static readonly Dictionary<int, string> _connectionMapping =
        new Dictionary<int, string>();

    public ChatHub(UserOperator userOperator, IMessageFunction messageFunction)
    {
        _userOperator = userOperator;
        _messageFunction = messageFunction;
    }

    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task SendMessageToUser(int fromUserId, int toUserId, string message)
    {
        var connectionIds = _connectionMapping.Where(x => x.Key == toUserId).Select(x => x.Value).ToList();

        await _messageFunction.AddMessage(fromUserId, toUserId, message);

        await Clients.Clients(connectionIds).SendAsync("ReceiveMessage", fromUserId, toUserId, message);
    }

    public override Task OnConnectedAsync()
    {
        var userId = _userOperator.GetRequestUser().UserId;

        if (!_connectionMapping.ContainsKey(userId))
            _connectionMapping.Add(userId, Context.ConnectionId);

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _connectionMapping.Remove(_userOperator.GetRequestUser().UserId);
        return base.OnDisconnectedAsync(exception);
    }
}
