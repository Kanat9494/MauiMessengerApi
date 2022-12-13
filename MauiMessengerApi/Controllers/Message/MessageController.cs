
namespace MauiMessengerApi.Controllers.Message;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MessageController : ControllerBase
{
    IMessageFunction _messageFunction;
    IUserFunction _userFunction;

    public MessageController(IMessageFunction messageFunction, IUserFunction userFunction)
    {
        _messageFunction = messageFunction;
        _userFunction = userFunction;
    }

    [HttpPost("Initialize")]
    public async Task<ActionResult> Initialize([FromBody] MessageInitializeRequest request)
    {
        var response = new MessageInitializeResponse()
        {
            FriendInfo = _userFunction.GetUserById(request.ToUserId),
            Messages = await _messageFunction.GetMessages(request.FromUserId, request.ToUserId)
        };

        return Ok(response);
    }
}
