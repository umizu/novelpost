using MediatR;
using Microsoft.AspNetCore.Mvc;
using novelpost.Application.Authentication.Commands.Register;
using novelpost.Application.Authentication.Common;
using novelpost.Application.Authentication.Queries.Login;
using novelpost.Contracts.Authentication;

namespace novelpost.Api.Controllers;

[Route("[controller]")]
public class AuthController : ApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Username,
            request.Email,
            request.Password
        );

        var registerResult = await _mediator.Send(command);

        return registerResult.Match(
           authResult => Ok(MapAuthResult(authResult)),
            error => Problem(error)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(
            request.Username,
            request.Password
        );

        var loginResult = await _mediator.Send(query);

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
