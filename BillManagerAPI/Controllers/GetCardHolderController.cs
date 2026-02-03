using BillManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillManagerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GetCardHolderController(DbContext context) : ControllerBase
{
    public async Task<IActionResult> obtainCardHolders()
    {
        var cardHolders = await context.Set<CardHolder>().ToListAsync();
        return Ok(cardHolders);
    }
}