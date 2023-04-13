using novelpost.Domain.Models;

namespace novelpost.Application.Features.Authentication.Common;

public record AuthResult(
    User User,
    string Token
);
