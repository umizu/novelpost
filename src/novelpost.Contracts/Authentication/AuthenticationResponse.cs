namespace novelpost.Contracts.Authentication;

public record AuthenticationResponse(
    string Token,
    string RefreshToken);
