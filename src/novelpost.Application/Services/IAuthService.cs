namespace novelpost.Application.Services;

public interface IAuthService
{
    AuthResult Register(string firstName, string lastName, string username, string email, string password);

    AuthResult Login(string username, string password);
}