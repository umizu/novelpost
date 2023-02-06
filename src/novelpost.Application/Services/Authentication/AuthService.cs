using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Application.Common.Interfaces.Persistence;
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

    public AuthResult Register(string firstName, string lastName, string username, string email, string password)
    {
        // Validate the user doesn't exist
        if (_userRepo.GetUserByEmail(email) is not null)
            throw new Exception("Account with this email already exists");
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

        // create user (with hashed password && unique id)
        _userRepo.Add(user);

        // generate JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token);
    }
    public AuthResult Login(string username, string password)
    {
        // Validate the user exists
        if (_userRepo.GetUserByUsername(username) is not User user)
            throw new Exception("User does not exist");

        // Validate the password is correct
        if (user.Password != password)
            throw new Exception("Password is incorrect");

        // generate JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token);
    }
}
