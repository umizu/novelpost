using novelpost.Application.Common.Interfaces.Authentication;

namespace novelpost.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string username, string email, string password)
    {
        // check if user exists

        // create user (with hashed password && unique id)

        // generate JWT Token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            username,
            email,
            token);
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
