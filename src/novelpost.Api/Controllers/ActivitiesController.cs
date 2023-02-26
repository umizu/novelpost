using MediatR;
using Microsoft.AspNetCore.Mvc;
using novelpost.Domain.Models;

namespace novelpost.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{
    // private readonly IMediator _mediator;

    // public ActivitiesController(IMediator mediator) => _mediator = mediator;

    // [HttpGet]
    // public async Task<IActionResult> GetActivities() => Ok(await _mediator.Send(new GetActivitiesQuery()));

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetActivity(Guid id) => Ok(await _mediator.Send(new GetActivityQuery { Id = id }));

    // [HttpPost]
    // public async Task<IActionResult> CreateActivity(Activity activity) => Ok(await _mediator.Send(new CreateActivityCommand { Activity = activity }));
}
