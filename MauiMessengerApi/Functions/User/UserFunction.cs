using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MauiMessengerApi.Functions.User;

public class UserFunction : IUserFunction
{
    private readonly ChatUserContext _chatUserContext;

    public UserFunction(ChatUserContext chatUserContext)
    {
        this._chatUserContext = chatUserContext;
    }

    public UserDTO? Authenticate(string phoneNumber, string password)
    {
        try
        {
            var user = _chatUserContext.ChatUsers.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (user == null) return null;

            var isPasswordMatched = VerifyPassword(password, user.StoredSalt, user.Password);
            if (!isPasswordMatched) return null;

            var token = GenerateJwtToken(user);

            return new UserDTO
            {
                UserId = user.UserId,
                PhoneNumber = user.PhoneNumber,
                Token = token
            };
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public UserDTO GetUserById(int userId)
    {
        throw new NotImplementedException();
    }

    private bool VerifyPassword(string enteredPassword, byte[] storedSalt, string storedPassword)
    {
        string encryptedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: enteredPassword,
            salt: storedSalt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return encryptedPassword.Equals(storedPassword);
    }

    private string GenerateJwtToken(ChatUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = AuthOptions.GetSymmetricSecurityKey();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.UserId.ToString()) }),
            Expires = DateTime.Now.AddMinutes(1),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
