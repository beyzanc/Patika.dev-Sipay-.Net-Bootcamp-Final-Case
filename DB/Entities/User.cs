using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiPay.DB.Entities
{
    [Table("User", Schema = "dbo")]
    public partial class User : BaseEntity
    {
        public User() {

            Bills = new HashSet<Bill>();
            Messages = new HashSet<Message>();
            Cards = new HashSet<Card>();
            Apartments = new HashSet<Apartment>();

        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? CarPlate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Status { get; set; }
        public int ApartmentId { get; set; }


        public virtual ICollection<Apartment> Apartments { get; set;} 
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Card> Cards { get; set; }


    }
}
