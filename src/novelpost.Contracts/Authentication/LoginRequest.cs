namespace novelpost.Contracts.Authentication;

public record LoginRequest(
    string Username,
    string Password
);
