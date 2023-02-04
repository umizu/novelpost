using Microsoft.EntityFrameworkCore;
using novelpost.Domain.Models;

namespace novelpost.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<Activity> Activities => Set<Activity>();
}
