using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class GetApiController(BasicEntity.AppDbContext context) : ControllerBase
{
    [HttpGet("obterDados")]
    public async Task<IActionResult> Get()
    {
        var categories = await context.Categories.ToListAsync();
        return Ok(categories);
    }
}

