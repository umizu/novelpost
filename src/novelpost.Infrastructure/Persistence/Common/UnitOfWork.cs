using novelpost.Application.Common.Interfaces.Persistence;

namespace novelpost.Infrastructure.Persistence.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDataContext _context;

    public UnitOfWork(IDataContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
