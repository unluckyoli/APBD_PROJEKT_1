using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public class SoftwareContract
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public bool IsPaid { get; set; }

    [Required]
    public int SoftwareId { get; set; }

    [ForeignKey(nameof(SoftwareId))]
    public virtual Software Software { get; set; }

    [Required]
    public int ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public virtual Client Client { get; set; }

    public ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>();

    public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
}

