using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController: ControllerBase
{   
    [HttpGet("eduardo")]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}