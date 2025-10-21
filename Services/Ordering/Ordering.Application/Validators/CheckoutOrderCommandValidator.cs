using FluentValidation;
using Ordering.Application.Commands;

namespace Ordering.Application.Validators
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName is required.")
                .MaximumLength(50)
                .WithMessage("UserName must not exceed 50 characters.");
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("EmailAddress is required.")
                .EmailAddress()
                .WithMessage("A valid EmailAddress is required.");
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0)
                .WithMessage("TotalPrice must be greater than zero.");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("First name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Last name is required");
        }
    }
}
