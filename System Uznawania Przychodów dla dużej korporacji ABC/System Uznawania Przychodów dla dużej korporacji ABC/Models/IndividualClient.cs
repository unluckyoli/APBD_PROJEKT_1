using System.ComponentModel.DataAnnotations;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public class IndividualClient : Client
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [StringLength(11)] //PESEL zawsze 11 cyfr
    public string PESEL { get; set; }
}