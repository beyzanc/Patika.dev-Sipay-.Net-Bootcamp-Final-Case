using ResiPay.Model.Mail;

namespace ResiPay.Service.Mail
{
    public interface IMailJobService
    {
        public MailResponseModel Send(MailRequestModel mailRequest);

    }
}
