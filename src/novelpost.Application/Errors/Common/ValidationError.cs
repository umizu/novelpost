using System.Net;

namespace novelpost.Application.Errors.Common;

public record ValidationError(
    List<(string propertyName, string errorMessage)> Errors
) : IValidationError
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string Title => "One or more validation errors occurred.";
    public List<(string propertyName, string errorMessage)> Errors { get; set; } = Errors;
}
