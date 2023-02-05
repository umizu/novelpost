using MediatR;
using novelpost.Domain.Models;
using novelpost.Persistence;

namespace novelpost.Application.Activities.Queries;

public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, Activity?>
{
    private readonly DataContext _context;

    public GetActivityQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Activity?> Handle(GetActivityQuery request, CancellationToken cancellationToken)
        => await _context.Activities.FindAsync(request.Id);
}
