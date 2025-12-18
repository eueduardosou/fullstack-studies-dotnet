using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class GetApiController(ApplicationDbContext context) : ControllerBase
{
    //[Authorize(Roles="Admin")]
    [HttpGet("obterDados")]
    public async Task<IActionResult> Get()
    {
        var categories = await context.Categories.ToListAsync();
        return Ok(categories);
    }
}

