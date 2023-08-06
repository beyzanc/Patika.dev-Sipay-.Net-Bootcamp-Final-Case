namespace ResiPay.Model.User
{
    public class UserInsertModel
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? CarPlate { get; set; }
        public int? ApartmentId { get; set; }
        public bool IsAdmin { get; set; }

    }
}
