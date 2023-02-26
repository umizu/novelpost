namespace novelpost.Contracts.Auth;

public record AuthResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Token);
