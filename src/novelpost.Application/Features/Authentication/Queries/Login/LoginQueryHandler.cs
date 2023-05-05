using MediatR;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Models;
using OneOf;
using novelpost.Application.Errors.Common;
using novelpost.Application.Errors.Auth;
using novelpost.Application.Features.Authentication.Common;
using novelpost.Application.Common.Interfaces.Auth;

namespace novelpost.Application.Features.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, OneOf<AuthResult, IError>>
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepo;

    public LoginQueryHandler(ITokenService tokenService, IUserRepository userRepo)
    {
        _tokenService = tokenService;
        _userRepo = userRepo;
    }

    public async Task<OneOf<AuthResult, IError>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepo.GetUserByUsernameAsync(query.Username) is not User user)
            return new InvalidCredentialsError();

        if (user.Password != query.Password)
            return new InvalidCredentialsError();

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateAndSetRefreshToken();

        return new AuthResult(
            user,
            accessToken,
            refreshToken.Token);
    }
}
