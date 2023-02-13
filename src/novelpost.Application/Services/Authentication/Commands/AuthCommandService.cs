using novelpost.Application.Common.Errors;
using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Application.Services.Authentication.Common;
using novelpost.Domain.Models;
using OneOf;

namespace novelpost.Application.Services.Authentication.Commands;

public class AuthCommandService : IAuthCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepo;

    public AuthCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepo)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepo = userRepo;
    }

    public OneOf<AuthResult, IError> Register(string firstName, string lastName, string username, string email, string password)
    {
        if (_userRepo.GetUserByEmail(email) is not null)
            return new DuplicateEmailError();
        if (_userRepo.GetUserByUsername(username) is not null)
            return new DuplicateUsernameError();

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
    public OneOf<AuthResult, IError> Login(string username, string password)
    {
        if (_userRepo.GetUserByUsername(username) is not User user)
            return new InvalidCredentialsError();

        if (user.Password != password)
            return new InvalidCredentialsError();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token);
    }
}
