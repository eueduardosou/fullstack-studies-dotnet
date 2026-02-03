using BillManagerAPI.Data;
using BillManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BillManagerAPI.Controllers;

public class AddTransactionController([FromBody] Transaction transaction, ApplicationDbContext context ): ControllerBase 
{
    public async Task<IActionResult> Post()
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