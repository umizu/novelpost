using Microsoft.AspNetCore.Mvc;
using novelpost.Contracts.Authentication;

namespace novelpost.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) => Ok(request);

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request) => Ok(request);
}
