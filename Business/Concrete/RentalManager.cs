using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using System.Linq;
using System.Linq.Expressions;
using Core.CrossCuttingConcerns.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Rental rental)
        {

            //ValidationTool.Validate(new RentalValidator(), rental);

            List<Rental> rentedCars = _rentalDal.GetAll(r => r.ReturnDate == null);

            var result = rentedCars.SingleOrDefault(r => r.CarId == rental.CarId);

            if (result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            else return new ErrorResult(Messages.AddErrorfromRent);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
