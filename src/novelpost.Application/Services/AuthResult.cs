namespace novelpost.Application.Services;

public record AuthResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Token
);
