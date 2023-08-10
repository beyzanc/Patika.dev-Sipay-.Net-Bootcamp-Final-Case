using FluentValidation;
using ResiPay.Model.Bill;
using System;
using System.Linq;

namespace ResiPay.Service.Validations.Bill
{
    public class BillInsertValidator : AbstractValidator<BillInsertModel>
    {
        public BillInsertValidator()
        {

            RuleFor(bill => bill.BillType).NotEmpty().WithMessage("Bill type is required.")
                .Must(BeAValidBillType).WithMessage("Please provide a valid bill type: dues, electric, gas, water, or other.");


            RuleFor(bill => bill.DueDate).NotNull().WithMessage("Due date of the bill is required.")
                .Must(DueDate => DueDate != default(DateTime)).WithMessage("Provide a valid date.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Due date must be greater than or equal to today's date.");

        }

        private bool BeAValidBillType(string billType)
        {
            string lowerCaseBillType = billType?.ToLower();

            string[] validBillTypes = { "dues", "electric", "gas", "water", "other" };

            return validBillTypes.Contains(lowerCaseBillType);
        }
    }



}
    


