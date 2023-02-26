using System.Net;

namespace novelpost.Application.Errors.Common;

public interface IError
{
    HttpStatusCode StatusCode { get; }
    string Title { get; }
}
