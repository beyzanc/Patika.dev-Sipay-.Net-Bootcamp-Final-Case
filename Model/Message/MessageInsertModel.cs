namespace ResiPay.Model.Message
{
    public class MessageInsertModel
    {
        public string Subject { get; set; } 
        public string Content { get; set; }
        public int ReceiverId { get; set; }
        public int UserId { get; set; }  

    }
}
