namespace novelpost.Contracts.Auth;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password
);
