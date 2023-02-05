using MediatR;
using novelpost.Domain.Models;

namespace novelpost.Application.Activities.Commands;

public class CreateActivityCommand : IRequest<bool>
{
    public Activity Activity { get; set; } = default!;
}
