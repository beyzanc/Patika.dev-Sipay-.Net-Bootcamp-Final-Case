namespace ResiPay.Model.Mail
{
    public class MailRequestModel
    {
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
