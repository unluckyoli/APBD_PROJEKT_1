namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.DTOs
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
