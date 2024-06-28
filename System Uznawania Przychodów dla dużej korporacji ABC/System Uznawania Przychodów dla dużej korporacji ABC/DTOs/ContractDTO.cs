namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.DTOs
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SoftwareId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public ICollection<DiscountDTO> Discounts { get; set; }
        public ICollection<PaymentDTO> Payments { get; set; }
    }
}
