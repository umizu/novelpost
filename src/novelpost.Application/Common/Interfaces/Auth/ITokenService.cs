using System.Security.Claims;
using novelpost.Domain.Identity;
using novelpost.Domain.Models;

namespace novelpost.Application.Common.Interfaces.Auth;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    RefreshToken GenerateAndSetRefreshToken();
}
