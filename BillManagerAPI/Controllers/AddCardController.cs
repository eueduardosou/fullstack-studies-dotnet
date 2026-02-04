using BillManagerAPI.Data;
using BillManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BillManagerAPI.Controllers;

public class AddCardController([FromBody] Card cardData, ApplicationDbContext context): ControllerBase
{
    public async Task<IActionResult> Post()
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