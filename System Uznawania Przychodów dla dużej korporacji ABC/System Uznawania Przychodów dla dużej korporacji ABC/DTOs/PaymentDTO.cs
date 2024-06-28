namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int ContractId { get; set; }
    }
}
