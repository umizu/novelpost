using novelpost.Application.Common.Errors;
using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Application.Services.Authentication.Common;
using novelpost.Domain.Models;
using OneOf;

namespace novelpost.Application.Services.Authentication.Queries;

public class AuthQueryService : IAuthQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepo;

    public AuthQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepo)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepo = userRepo;
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
