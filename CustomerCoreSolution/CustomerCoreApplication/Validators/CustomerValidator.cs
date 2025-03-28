using CustomerCoreApplication.DTOs;
using FluentValidation;

namespace CustomerCoreApplication.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Invalid email.");
            RuleFor(c => c.PhoneNumber).Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits.");
        }
    }
}