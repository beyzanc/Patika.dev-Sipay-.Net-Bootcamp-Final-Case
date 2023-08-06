using ResiPay.DB.Enums;
using System;
using System.Text.Json.Serialization;

namespace ResiPay.Model.Bill
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public string BillType { get; set; }
        public decimal BillAmount { get; set; } 
        public Month Month { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime InsertDate { get; set; }

    }
}
