using System.Net;
using novelpost.Application.Errors.Common;

namespace novelpost.Application.Errors.Auth;

public record struct DuplicateUsernameError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string Title => "This username is already taken";
}
