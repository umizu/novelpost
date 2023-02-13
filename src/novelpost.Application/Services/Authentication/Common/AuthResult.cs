using novelpost.Domain.Models;

namespace novelpost.Application.Services.Authentication.Common;

public record AuthResult(
    User User,
    string Token
);
