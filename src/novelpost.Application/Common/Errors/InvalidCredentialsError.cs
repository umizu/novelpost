using System.Net;

namespace novelpost.Application.Common.Errors;

public record struct InvalidCredentialsError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public string ErrorMessage => "Invalid credentials.";
}
