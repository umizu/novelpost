using MediatR;
using novelpost.Persistence;

namespace novelpost.Application.Activities.Commands;

public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, bool>
{
    private readonly DataContext _context;

    public CreateActivityCommandHandler(DataContext context) => _context = context;

    public async Task<bool> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        _context.Activities.Add(request.Activity);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
