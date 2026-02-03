using System.ComponentModel.DataAnnotations;

namespace BillManagerAPI.Entities;

public class Category
{
    public Guid Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
}