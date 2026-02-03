using Microsoft.AspNetCore.Mvc;

namespace BillManagerAPI.Controllers;

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