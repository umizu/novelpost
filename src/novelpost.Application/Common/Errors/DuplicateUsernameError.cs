using System.Net;

namespace novelpost.Application.Common.Errors;

public record struct DuplicateUsernameError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "This username is already taken.";
}
