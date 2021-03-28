using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.ModelYear).GreaterThan(1900);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.ColorId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).Must(LengthRule);
        }

        private bool LengthRule(string arg)
        {
            return arg.Length > 2;
        }
    }
}
