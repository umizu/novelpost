using novelpost.Domain.Models;

namespace novelpost.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
