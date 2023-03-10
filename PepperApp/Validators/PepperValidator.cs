using FluentValidation;
using PepperApp.Entities;

namespace PepperApp.Validators
{
    public class PepperValidator : AbstractValidator<Pepper>
    {
        public PepperValidator()
        {
            RuleFor(x => x.PepperName)
                .NotEmpty()
                .Length(1, 100);

            RuleFor(x => x.PepperScovilleUnitMinimum)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(5000000);

            RuleFor(x => x.PepperScovilleUnitMaximum)
                .GreaterThanOrEqualTo(x => x.PepperScovilleUnitMinimum)
                .LessThanOrEqualTo(5000000);
        }
    }
}
