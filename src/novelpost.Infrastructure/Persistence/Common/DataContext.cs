using Microsoft.EntityFrameworkCore;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Identity;
using novelpost.Domain.Models;

namespace novelpost.Infrastructure.Persistence.Common;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set;} = null!;
}
