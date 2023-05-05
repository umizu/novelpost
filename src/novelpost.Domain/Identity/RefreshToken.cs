using novelpost.Domain.Models;

namespace novelpost.Domain.Identity;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; } = null!;
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public Guid UserId { get; set; }
}
