namespace MauiMessengerApi.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context, IUserFunction userFunction)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
            AttachUserToContext(context, userFunction, token);

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, IUserFunction userFunction, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = AuthOptions.GetSymmetricSecurityKey();
            string validToken = "";
            if (token.StartsWith("Bearer"))
                validToken = token.Substring(6);
            else
                validToken = token;
            tokenHandler.ValidateToken(validToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);

            context.Items["User"] = userFunction.GetUserById(userId);
        }
        catch (Exception ex)
        {

        }
    }
}
