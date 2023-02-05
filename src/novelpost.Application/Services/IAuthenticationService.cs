namespace novelpost.Application.Services;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lastName, string username, string email, string password);

    AuthenticationResult Login(string email, string password);
}
