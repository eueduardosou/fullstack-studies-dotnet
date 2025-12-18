using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    
    private readonly string _issuer;
    private readonly string _audience;
    private readonly SymmetricSecurityKey _signingKey;

    public AuthController(IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("JwtSettings");
        _issuer = jwtSection["Issuer"] ?? throw new InvalidOperationException("Issuer ausente");
        _audience = jwtSection["Audience"] ?? throw new InvalidOperationException("Audience ausente");
        var secret = jwtSection["SecretKey"] ?? throw new InvalidOperationException("SecretKey ausente");
        _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin user)
    {
        if (user.Username != "admin" || user.Password != "password") return Unauthorized();
        var token = GenerateJwtToken(user.Username);
        return Ok(new { token });
    }

    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}