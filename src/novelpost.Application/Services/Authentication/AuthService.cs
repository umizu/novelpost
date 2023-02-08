using ErrorOr;
using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Common.Errors;
using novelpost.Domain.Models;

namespace novelpost.Application.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepo;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepo)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepo = userRepo;
    }

    public ErrorOr<AuthResult> Register(string firstName, string lastName, string username, string email, string password)
    {
        if (_userRepo.GetUserByEmail(email) is not null)
            return Errors.User.DuplicateEmail;
        if (_userRepo.GetUserByUsername(username) is not null)
            throw new Exception("Account with this username already exists");

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Username = username,
            Email = email,
            Password = password
        };

        _userRepo.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token);
    }
    public ErrorOr<AuthResult> Login(string username, string password)
    {
        if (_userRepo.GetUserByUsername(username) is not User user)
            return Errors.Auth.InvalidCredentials;

        if (user.Password != password)
            return Errors.Auth.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token);
    }
}
