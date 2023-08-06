using FluentValidation;
using ResiPay.Model.Apartment;
using System.Text.RegularExpressions;

namespace ResiPay.Service.Validations.Apartment
{
    public class ApartmentInsertValidator : AbstractValidator<ApartmentInsertModel>
    {
        public ApartmentInsertValidator() {

            RuleFor(apartment => apartment.ApartmentBlock).NotEmpty().WithMessage("Apartment block is required.")
                .Length(1, 15).WithMessage("Block name must be between 1 and 15 chars.");

            RuleFor(apartment => apartment.ApartmentFloor).NotEmpty().WithMessage("Apartment floor is required.")
                .InclusiveBetween(-4, 30).WithMessage("Floor value must be between -4 and 30.");

            RuleFor(apartment => apartment.ApartmentNumber).NotEmpty().WithMessage("Apartment number is required.")
                .LessThan(300).WithMessage("Apartment number must be less than 300.");

            RuleFor(apartment => apartment.IsFull).NotNull().WithMessage("Apartment status is required.");

            RuleFor(apartment => apartment.ApartmentType).NotEmpty().WithMessage("Apartment type is required.")
                .Must(BeValidApartmentType).WithMessage("Invalid apartment type. Please provide a value like 2+1,3+0 or type 'other'.");
                           
        }

        private bool BeValidApartmentType(string apartmentType)
        {
            return apartmentType == "other" || Regex.IsMatch(apartmentType, @"^\d+\+\d+$");

        }
    }
}
