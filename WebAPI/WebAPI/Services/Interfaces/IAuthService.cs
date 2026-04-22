using WebAPI.Models;

public interface IAuthService
{
    Task<string?> Login(string login, string password);
    Task<User> Register(User user);
}