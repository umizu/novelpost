using MediatR;
using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Models;
using OneOf;
using novelpost.Application.Authentication.Common;
using novelpost.Application.Errors.Common;
using novelpost.Application.Errors.Auth;

namespace novelpost.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, OneOf<AuthResult, IError>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepo;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepo)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepo = userRepo;
    }

    public async Task<OneOf<AuthResult, IError>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepo.GetUserByUsername(query.Username) is not User user)
            return new InvalidCredentialsError();

        if (user.Password != query.Password)
            return new InvalidCredentialsError();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token);
    }
}
