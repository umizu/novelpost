using System.Net;
using novelpost.Application.Errors.Common;

namespace novelpost.Application.Errors.Auth;

public record struct InvalidCredentialsError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public string Title => "Invalid credentials";
}
