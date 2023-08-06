namespace ResiPay.Model.Apartment
{
    public class ApartmentViewModel
    {
        public int Id { get; set; }
        public string ApartmentBlock { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNumber { get; set; }
        public bool IsFull { get; set; }
        public bool IsRented { get; set; }
        public string ApartmentType { get; set; }

    }
}
