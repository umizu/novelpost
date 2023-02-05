using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using novelpost.Application.Activities;
using novelpost.Application.Activities.Commands;
using novelpost.Application.Activities.Queries;
using novelpost.Domain.Models;
using novelpost.Persistence;

namespace novelpost.Api.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetActivities() => Ok(await Mediator.Send(new GetActivitiesQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id) => Ok(await Mediator.Send(new GetActivityQuery { Id = id }));

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Activity activity) => Ok(await Mediator.Send(new CreateActivityCommand { Activity = activity }));
}
