using FluentValidation;
using ResiPay.Model.User;

namespace ResiPay.Service.Validations.User
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequestModel>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage("E-mail is requried.")
                .EmailAddress().WithMessage("Please provide a valid email.");

            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required."); 
        
        }
    }
}
