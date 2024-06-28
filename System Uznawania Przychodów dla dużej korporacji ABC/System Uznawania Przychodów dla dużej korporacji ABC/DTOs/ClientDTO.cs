namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class IndividualClientDTO : ClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
    }

    public class CompanyClientDTO : ClientDTO
    {
        public string CompanyName { get; set; }
        public string KRS { get; set; }
    }
}
