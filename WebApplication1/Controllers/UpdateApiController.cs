using Microsoft.AspNetCore.Mvc;

using WebApplication1.Entities;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class UpdateApiController(BasicEntity.AppDbContext context) : ControllerBase
{
    [HttpPost("atualizar")]
    public async Task<OkObjectResult> Post()
    {
       await context.Categories.AddAsync(new BasicEntity.Category
        {
            Title = "Categoria Exemplo",
            Slug = "categoria-exemplo",
            Description = "Descrição da categoria exemplo"
        });
        await context.SaveChangesAsync();
        return Ok("Categoria criada com sucesso!");
    }
}