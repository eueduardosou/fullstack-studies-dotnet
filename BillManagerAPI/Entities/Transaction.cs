using System.ComponentModel.DataAnnotations;

namespace BillManagerAPI.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    // Foreign Key using Guid
    public Guid? CardId { get; set; }
        
    // Navigation Property (Unidirectional)
    public Card? Card { get; set; }
        
    public Guid NatureId { get; set; }
    public TransactionNature Nature { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}