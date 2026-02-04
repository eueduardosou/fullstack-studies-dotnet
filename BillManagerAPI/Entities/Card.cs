using System.ComponentModel.DataAnnotations;

namespace BillManagerAPI.Entities;

public class Card
    {
        public Guid Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public string BankHolder { get; set; }
        public int ClosingDay { get; set; }
    }