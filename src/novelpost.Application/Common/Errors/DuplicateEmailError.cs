using System.Net;

namespace novelpost.Application.Common.Errors;

public record struct DuplicateEmailError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "A user with this email already exists.";
}
