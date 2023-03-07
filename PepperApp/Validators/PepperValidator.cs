using FluentValidation;
using PepperApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperApp.Validators
{
    public class PepperValidator : AbstractValidator<Pepper>
    {
        public PepperValidator() 
        { 
            RuleFor(x => x.PepperName)
                .NotEmpty()
                .Length(1, 100);

            RuleFor(x => x.PepperScovilleUnitMin)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(5000000);

            RuleFor(x => x.PepperScovilleUnitMax)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(5000000);
        }
    }
}
