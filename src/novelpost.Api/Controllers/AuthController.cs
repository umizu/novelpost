using System.Collections.Generic;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using novelpost.Application.Services.Authentication;
using novelpost.Contracts.Authentication;

namespace novelpost.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthResult> authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Username,
            request.Email,
            request.Password
        );

        return authResult.MatchFirst(
           authResult => Ok(MapAuthResult(authResult)),
            firstError => Problem(statusCode: 500, title: firstError.Description)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(
            request.Email,
            request.Password
        );

        return authResult.MatchFirst(
            authResult => Ok(MapAuthResult(authResult)),
            firstError => Problem(statusCode: 500, title: firstError.Description)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Username,
            authResult.User.Email,
            authResult.Token);
    }
}
