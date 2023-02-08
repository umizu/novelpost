using novelpost.Application.Common.Errors;
using OneOf;

namespace novelpost.Application.Services.Authentication;

public interface IAuthService
{
    OneOf<AuthResult, IError> Register(string firstName, string lastName, string username, string email, string password);

    OneOf<AuthResult, IError> Login(string username, string password);
}
