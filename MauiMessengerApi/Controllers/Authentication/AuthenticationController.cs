
using MauiMessengerApi.Models.DTOs.Requests;

namespace MauiMessengerApi.Controllers.Authentication;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private IUserFunction _userFunction; 

    public AuthenticationController(IUserFunction userFunction)
    {
        _userFunction = userFunction;
    }

    [HttpPost("AuthenticateUser")]
    public async Task<IActionResult> AuthenticateUser(AuthenticateRequest request)
    {
        var response = _userFunction.Authenticate(request.PhoneNumber, request.Password);
        if (response == null)
            return BadRequest(new { message = "Неправильный логин или пароль!" });

        return Ok(response);
    }
}
