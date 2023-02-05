using MediatR;
using novelpost.Domain.Models;

namespace novelpost.Application.Activities.Queries;

public class GetActivityQuery : IRequest<Activity?>
{
    public Guid Id { get; set; }
}
