using System;

namespace ResiPay.Model.Bill
{
    public class BillInsertModel
    {
        public string BillType { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set;}
        public decimal BillAmount { get; set; }

    }
}
