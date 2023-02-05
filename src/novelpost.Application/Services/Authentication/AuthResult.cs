using novelpost.Domain.Models;

namespace novelpost.Application.Services.Authentication;

public record AuthResult(
    User User,
    string Token
);
