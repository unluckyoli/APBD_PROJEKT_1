using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }
    

    [Required]
    public DateTime PaymentDate { get; set; }

    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public int ContractId { get; set; }

    [ForeignKey(nameof(ContractId))] public SoftwareContract Contract { get; set; } = null!;
}
