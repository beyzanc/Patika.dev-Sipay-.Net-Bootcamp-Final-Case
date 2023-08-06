using FluentValidation;
using ResiPay.Model.Message;

namespace ResiPay.Service.Validations.Message
{
    public class MessageInsertValidator : AbstractValidator<MessageInsertModel>
    {
        public MessageInsertValidator()
        {
            RuleFor(message => message.Subject)
                .NotEmpty().WithMessage("Subject of the message is required.")
                .Length(4, 20).WithMessage("The subject must be between 4 and 20 chars.");

            RuleFor(message => message.Content)
                .NotEmpty().WithMessage("Content of the message is required.")
                .Length(10, 150).WithMessage("The content must be between 10 and 150 chars.");

            RuleFor(message => message.ReceiverId)
                .NotEmpty().WithMessage("Receiver ID is required.");

            RuleFor(message => message.UserId)
                .NotEmpty().WithMessage("Sender ID is required.");

            
        }
    }
}
