using BillManagerAPI.Data;
using BillManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BillManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddTransactionController(ApplicationDbContext context ): ControllerBase 
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Transaction transaction)
    {
        await context.Transactions.AddAsync(new Transaction
        {
            Description = transaction.Description,
            Amount = transaction.Amount,
            Date = transaction.Date,
            Category =  transaction.Category,
            Nature =  transaction.Nature,
        });
        await context.SaveChangesAsync();
        return Ok("Transação adicionada com sucesso!");
    }
}