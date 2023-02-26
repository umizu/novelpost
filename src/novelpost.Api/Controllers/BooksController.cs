using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace novelpost.Api.Controllers;

[Route("[controller]")]
public class BooksController : ApiController
{
    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(Array.Empty<string>());
    }
}
