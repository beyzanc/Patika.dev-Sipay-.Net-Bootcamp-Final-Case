using FluentValidation;
using ResiPay.Model.User;
using System;
using System.Linq;

namespace ResiPay.Service.Validations.User
{
    public class UserInsertValidator : AbstractValidator<UserInsertModel>
    {
        public UserInsertValidator()
        {


            RuleFor(user => user.Name).NotEmpty().WithMessage("Name can not be empty.")
                .Length(2, 40).WithMessage("The name must be between 2 and 40 characters.");

            RuleFor(user => user.Surname).NotEmpty().WithMessage("Surname can not be empty.")
                .Length(2, 40).WithMessage("The surname must be between 2 and 40 characters.");

            RuleFor(user => user.IdentityNumber).NotEmpty().WithMessage("Identity number can not be empty.")
                .Length(11).WithMessage("Identity number must be exactly 11 digits.")
                .Must(BeValidIdentityNumber).WithMessage("Provide a valid identity number.");

            RuleFor(user => user.Email).NotEmpty().WithMessage("Email can not be empty.")
                .EmailAddress().WithMessage("Please provide a valid email.");

            RuleFor(user => user.PhoneNumber).NotEmpty().WithMessage("Phone number can not be empty.")
                .Matches(@"^(\+90|0)?\s*(\(\d{3}\)[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}|\(\d{3}\)[\s-]*\d{3}[\s-]*\d{4}|\(\d{3}\)[\s-]*\d{7}|\d{3}[\s-]*\d{3}[\s-]*\d{4}|\d{3}[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2})$")
                .WithMessage("Provide a valid phone number.");

            RuleFor(user => user.CarPlate).Matches(@"^([0-9]{2})([A-Z]{1,3})([0-9]{2,4})$").WithMessage("Provide a valid plate number of the car.");

            RuleFor(user => user.ApartmentId).GreaterThan(0).WithMessage("Provide a value greater than {0}");

            RuleFor(user => user.Status).NotEmpty().WithMessage("User status is required.")
                .Must(BeValidStatus).WithMessage("Provide a valid user status: Admin or Resident");

        }

        private bool BeValidIdentityNumber(string identityNumber)
        {
            if (!IsNumeric(identityNumber) || identityNumber.Length != 11)
                return false;

            int d1 = int.Parse(identityNumber[0].ToString());
            int d2 = int.Parse(identityNumber[1].ToString());
            int d3 = int.Parse(identityNumber[2].ToString());
            int d4 = int.Parse(identityNumber[3].ToString());
            int d5 = int.Parse(identityNumber[4].ToString());
            int d6 = int.Parse(identityNumber[5].ToString());
            int d7 = int.Parse(identityNumber[6].ToString());
            int d8 = int.Parse(identityNumber[7].ToString());
            int d9 = int.Parse(identityNumber[8].ToString());

            int c1 = ((d1 + d3 + d5 + d7 + d9) * 7 - (d2 + d4 + d6 + d8)) % 10;
            int c2 = (d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + c1) % 10;

            if (c1 != int.Parse(identityNumber[9].ToString()) || c2 != int.Parse(identityNumber[10].ToString()))
                return false;

            if (d1 == 0)
                return false;

            return true;
        }

        private bool IsNumeric(string value)
        {
            return long.TryParse(value, out _);
        }


        private bool BeValidStatus(string status)
        {
            string lowerCaseStatus = status?.ToLower();

            string[] validStatusTypes = { "admin", "resident" };

            return validStatusTypes.Contains(lowerCaseStatus);
        }
    }
}
