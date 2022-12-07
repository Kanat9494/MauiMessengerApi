using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MauiMessengerApi;

public class AuthOptions
{
    public const string ISSUER = "http://192.168.1.51:45455"; // издатель токена
    public const string AUDIENCE = "http://192.168.1.51:45455"; // потребитель токена
    const string KEY = "#2klm;LKEOK23)*($_#@OPWM,fmklsdp2_)_(*ASDFMK=345KLMFS_2348#^#%%^*(&$%#L;KSJDFG";   // ключ для шифрации
    public const int LIFETIME = 1; // время жизни токена - 1 минута
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
