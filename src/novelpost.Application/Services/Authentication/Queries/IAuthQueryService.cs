using novelpost.Application.Common.Errors;
using novelpost.Application.Services.Authentication.Common;
using OneOf;

namespace novelpost.Application.Services.Authentication.Queries;

public interface IAuthQueryService
{
    OneOf<AuthResult, IError> Login(string username, string password);
}
