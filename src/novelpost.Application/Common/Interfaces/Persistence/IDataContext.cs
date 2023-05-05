using Microsoft.EntityFrameworkCore;
using novelpost.Domain.Identity;
using novelpost.Domain.Models;

namespace novelpost.Application.Common.Interfaces.Persistence;

public interface IDataContext
{
    DbSet<User> Users { get; set; }
    DbSet<RefreshToken> RefreshTokens { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
