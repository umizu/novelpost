using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using novelpost.Application.Services.Authentication;
using novelpost.Contracts.Authentication;

namespace novelpost.Api.Controllers;

[Route("[controller]")]
public class AuthController : ApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Username,
            request.Email,
            request.Password
        );

        return registerResult.Match(
           authResult => Ok(MapAuthResult(authResult)),
            error => Problem(error)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authService.Login(
            request.Email,
            request.Password
        );

        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
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
