using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using novelpost.Application.Errors.Common;

namespace novelpost.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(IError error)
    {
        return error switch
        {
            IValidationError validationError => MapToValidationProblem(validationError),
            _ => Problem(statusCode: (int)error.StatusCode, title: error.Title)
        };
    }

    private IActionResult MapToValidationProblem(IValidationError error)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var (propertyName, errorMessage) in error.Errors)
        {
            modelStateDictionary.AddModelError(propertyName, errorMessage);
        }

        return ValidationProblem(
            statusCode: (int)error.StatusCode,
            title: error.Title,
            modelStateDictionary: modelStateDictionary);
    }
}
