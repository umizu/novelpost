using MediatR;
using novelpost.Persistence;

namespace novelpost.Application.Activities.Commands;

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, bool>
{
    public Task<bool> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
         throw new NotImplementedException();
    }
}
