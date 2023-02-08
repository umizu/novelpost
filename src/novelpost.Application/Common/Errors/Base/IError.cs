using System.Net;

namespace novelpost.Application.Common.Errors;

public interface IError
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}
