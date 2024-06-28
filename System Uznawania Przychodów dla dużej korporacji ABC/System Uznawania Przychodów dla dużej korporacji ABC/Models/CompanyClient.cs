using System.ComponentModel.DataAnnotations;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public class CompanyClient : Client
{
    [Required]
    public string CompanyName { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 9)] //KRS powinien miec dlugosc od 9 do 14 cyfr wedlug www.biznes.gov.pl
    public string KRS { get; set; }
}