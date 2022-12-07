namespace MauiMessengerApi.Functions.User;

public interface IUserFunction
{
    UserDTO? Authenticate(string phoneNumber, string password); 
    UserDTO GetUserById(int userId);
}
