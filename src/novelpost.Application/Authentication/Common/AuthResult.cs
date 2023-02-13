using novelpost.Domain.Models;

namespace novelpost.Application.Authentication.Common;

public record AuthResult(
    User User,
    string Token
);
