using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers;
[EnableCors]
[ApiController]
[Route("[controller]")]
public class AuthorizationApiController(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager)
    : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return Ok(new { message = "Usuário criado com sucesso", userId = user.Id });
        }

        return BadRequest(result.Errors);
    }
}