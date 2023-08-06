using System;

namespace ResiPay.Model.Bill
{
    public class BillUpdateModel
    {
        public int Id { get; set; }
        public string BillType { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }
        public decimal BillAmount { get; set; }
    }
}
