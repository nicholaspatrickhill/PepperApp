using FluentValidation;
using PepperApp.DataTransferObject;

namespace PepperApp.Validators
{
    public class PepperValidator : AbstractValidator<PepperDto>
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
