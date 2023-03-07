using FluentValidation;
using PepperApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperApp.Validators
{
    internal class PepperValidator : AbstractValidator<Pepper>
    {
        public PepperValidator() 
        { 
            RuleFor(x => x.PepperName).NotEmpty();
            RuleFor(x => x.PepperId).NotEmpty();
            RuleFor(x => x.PepperHeatClass).NotEmpty();
            RuleFor(x => x.PepperScovilleUnitMin).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PepperScovilleUnitMax).LessThanOrEqualTo(5000000);
        }

    }
}
