using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.CarId).GreaterThan(1900);
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Id).NotNull();
        }
    }
}
