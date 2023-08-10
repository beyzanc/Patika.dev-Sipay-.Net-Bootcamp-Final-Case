using ResiPay.DB.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiPay.DB.Entities
{
    [Table("Bill", Schema = "dbo")]

    public partial class Bill : BaseEntity
    {       
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public string BillType { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime DueDate { get; set; }
        public Month Month { get; set; }
        public bool IsPaid { get; set; }
            

        public virtual Apartment Apartment { get; set; } 
        public virtual User User { get; set; } 

    }
}
