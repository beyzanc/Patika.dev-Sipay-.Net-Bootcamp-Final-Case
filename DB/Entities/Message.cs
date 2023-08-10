using System.ComponentModel.DataAnnotations.Schema;

namespace ResiPay.DB.Entities
{
    [Table("Message", Schema = "dbo")]

    public partial class Message : BaseEntity
    {
        public string Subject { get; set; } 
        public string Content { get; set; } 
        public int UserId { get; set; }  
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string SenderName { get; set; }
        public string SenderSurname { get; set; }
        
        public virtual User User { get; set; } 

    }
}
