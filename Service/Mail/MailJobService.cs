using AutoMapper;
using MimeKit;
using ResiPay.DB;
using ResiPay.Model.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using ResiPay.Service.Bill;
using MimeKit.Text;

namespace ResiPay.Service.Mail
{
    public class MailJobService : IMailJobService
    {
        private readonly IMapper mapper;
        private readonly ResiPayDbContext dbContext;
        private readonly IBillService billService;

        public MailJobService(IMapper _mapper, ResiPayDbContext dbContext, IBillService billService)
        {
            this.mapper = _mapper;
            this.dbContext = dbContext;
            this.billService = billService;

        }

        public MailResponseModel Send(MailRequestModel mailRequest)
        {
            try
            {
                var unpaidBillsBase = billService.GetNotPaidBills();
                var unpaidBillsList = mapper.Map<List<ResiPay.DB.Entities.Bill>>(unpaidBillsBase); 

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("alexie.mante@ethereal.email", "Bx9BttFXk5NZ4arfS9");

                int count = unpaidBillsList.Count;


                for (int i = count - 1; i >= 0; i--)
                {
                    var bill = unpaidBillsList[i];

                    var request = new MailRequestModel
                    {
                        ReceiverMail = bill.User.Email,
                        Subject = "Payment Reminder",
                        Body = $"Dear {bill.User.Name},\n\nWe hope this message finds you well." +
                        $"We kindly remind you about your {bill.BillType} invoice, which is due for payment on {bill.DueDate.ToShortDateString()}. " +
                        $"The total amount to be paid is {bill.BillAmount} TL. " +
                        $"We would like to kindly request you to settle the payment by the specified due date.\n\n" +
                        $"Thank you for your attention. Should you have any questions or require further assistance, please don't hesitate to reach out to us!\n\n" +
                        $"Best regards,\n\nThe ResiPay Team"
                    };

                    var message = new MimeMessage();
                    message.From.Add(MailboxAddress.Parse("alexie.mante@ethereal.email"));
                    message.To.Add(MailboxAddress.Parse(request.ReceiverMail));
                    message.Subject = request.Subject;
                    message.Body = new TextPart(TextFormat.Plain) { Text = request.Body };

                    smtp.Send(message);

                }

                smtp.Disconnect(true);

                return new MailResponseModel 
                { 
                    IsSuccess = true,
                    Message = "Reminders sent successfully." 

                };
            }
            catch (Exception ex)
            {
                return new MailResponseModel 
                { 
                    IsSuccess = false, 
                    ErrorMessage = ex.Message 

                };
            }
        }
    }
}
