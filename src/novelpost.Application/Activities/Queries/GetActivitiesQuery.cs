using MediatR;
using novelpost.Domain.Models;

namespace novelpost.Application.Activities.Queries;

public class GetActivitiesQuery : IRequest<List<Activity>> { }
