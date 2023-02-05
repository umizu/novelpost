namespace novelpost.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string username, string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            username,
            email,
            "token");
    }
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            "username",
            email,
            "token"
        );
    }

}
