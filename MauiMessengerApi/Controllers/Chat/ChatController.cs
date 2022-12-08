namespace MauiMessengerApi.Controllers.Chat;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ChatController : ControllerBase
{
    IUserFunction _userFunction;
    IUserFriendService _userFriendService;
    IMessageFunction _messageFunction;

    public ChatController(IUserFunction userFunction, IUserFriendService userFriendService, IMessageFunction messageFunction)
    {
        _userFunction = userFunction;
        _userFriendService = userFriendService;
        _messageFunction = messageFunction;
    }

    [HttpPost("Initialize")]
    public async Task<ActionResult> Initialize([FromBody] int userId)
    {
        var response = new ChatsInitializeResponse
        {
            User = _userFunction.GetUserById(userId),
            UserFriends = await _userFriendService.GetUserFriendsAsync(userId),
            LastestMessages = await _messageFunction.GetLastestMessage(userId)
        };

        return Ok(response);
    }
}
