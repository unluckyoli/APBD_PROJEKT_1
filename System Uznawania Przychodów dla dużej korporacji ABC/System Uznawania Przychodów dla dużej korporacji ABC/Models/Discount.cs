using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public class Discount
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal Percentage { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))] 
    public Product Product { get; set; } = null!;
}
