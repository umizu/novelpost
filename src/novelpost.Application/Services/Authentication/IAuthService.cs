using ErrorOr;

namespace novelpost.Application.Services.Authentication;

public interface IAuthService
{
    ErrorOr<AuthResult> Register(string firstName, string lastName, string username, string email, string password);

    ErrorOr<AuthResult> Login(string username, string password);
}
