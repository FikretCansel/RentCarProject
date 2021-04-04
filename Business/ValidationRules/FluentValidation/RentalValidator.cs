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
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kayıt olmanız Gerekmekte");
            RuleFor(x => x.ReturnDate).GreaterThan(x => x.RentDate);
            RuleFor(x => x.CarId).NotNull();
        }
    }
}
