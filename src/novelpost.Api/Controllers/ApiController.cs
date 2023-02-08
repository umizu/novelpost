using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using novelpost.Application.Common.Errors;

namespace novelpost.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(IError error)
    {
        return Problem(
            statusCode: (int)error.StatusCode,
            title: error.ErrorMessage);
    }
}
