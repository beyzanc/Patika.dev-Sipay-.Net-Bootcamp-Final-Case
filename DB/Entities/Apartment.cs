using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiPay.DB.Entities
{
    [Table("Apartment", Schema = "dbo")]

    public partial class Apartment : BaseEntity
    {
        public Apartment() {
            Users = new HashSet<User>();
            Bills = new HashSet<Bill>();
        
        }

        public string ApartmentBlock { get; set; }
        public int ApartmentFloor { get; set; }
        public int ApartmentNumber { get; set; }
        public string ApartmentType { get; set; }
        public bool IsFull { get; set; }
        public bool IsRented { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Bill> Bills { get; set; } 


    }
}
