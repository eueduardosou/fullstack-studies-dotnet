using BillManagerAPI.Data;
using BillManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillManagerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GetCardHolderController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> obtainCardHolders()
    {
        var cardHolders = await context.Set<CardHolder>().ToListAsync();
        return Ok(cardHolders);
    }
}