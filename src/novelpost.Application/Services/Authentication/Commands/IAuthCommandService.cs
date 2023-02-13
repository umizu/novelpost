using novelpost.Application.Common.Errors;
using novelpost.Application.Services.Authentication.Common;
using OneOf;

namespace novelpost.Application.Services.Authentication.Commands;

public interface IAuthCommandService
{
    OneOf<AuthResult, IError> Register(string firstName, string lastName, string username, string email, string password);

}
