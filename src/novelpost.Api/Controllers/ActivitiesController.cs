using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using novelpost.Persistence;

namespace novelpost.Api.Controllers;

public class ActivitiesController : BaseApiController
{
    private readonly DataContext _context;

    public ActivitiesController(DataContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetActivities() => Ok(await _context.Activities.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id) => Ok(await _context.Activities.FindAsync(id));
}
