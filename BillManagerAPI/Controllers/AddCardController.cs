using BillManagerAPI.Data;
using BillManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BillManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddCardController(ApplicationDbContext context): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Card cardData)
    {
        await context.Cards.AddAsync(new Card
        {
            Name = cardData.Name,
            ClosingDay = cardData.ClosingDay,
            BankHolder = cardData.BankHolder
        });
        await context.SaveChangesAsync();
        return Ok("Cartão adicionado com sucesso!");
    }
}