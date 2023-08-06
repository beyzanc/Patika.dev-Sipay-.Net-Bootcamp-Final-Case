using System;

namespace ResiPay.Model.Message
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int ReceiverId { get; set; }
        public int UserId { get; set; }
        public bool IsRead { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
