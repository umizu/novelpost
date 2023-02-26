using System.Net;
using novelpost.Application.Errors.Common;

namespace novelpost.Application.Errors.Auth;

public record struct DuplicateEmailError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string Title => "A user with this email already exists";
}
