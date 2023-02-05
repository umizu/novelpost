using MediatR;
using Microsoft.EntityFrameworkCore;
using novelpost.Domain.Models;
using novelpost.Persistence;

namespace novelpost.Application.Activities.Queries;

public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, List<Activity>>
{
    private readonly DataContext _context;

    public GetActivitiesQueryHandler(DataContext context) => _context = context;

    public async Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        => await _context.Activities.ToListAsync();
}
