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
using Entities.DTO;
using Core.Aspects.Autofac.Transaction;

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
        public IDataResult<List<Rental>> GetUserRental(int UserId)
        {
            var result = _rentalDal.GetAll(r=>r.UserId==UserId);
            if (result == null)
            {
                return new ErrorDataResult<List<Rental>>(Messages.NotFoundYourRental);
            }
            return new SuccessDataResult<List<Rental>>(result,Messages.FoundedRental);
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

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails(), Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
        public IResult IsRentable(DateTime rentDate,DateTime returnDate,int carId)
        {
            var rentHistory=_rentalDal.GetAll(r => r.CarId == carId);
            if (rentDate < DateTime.Now || returnDate < DateTime.Now)
            {
                return new ErrorResult(Messages.PastHistoryError);
            }
            foreach (var history in rentHistory)
            {
                if (rentDate>history.RentDate && rentDate<history.ReturnDate ||rentDate<=history.RentDate&&returnDate>history.RentDate)
                {
                    return new ErrorResult(Messages.noRentable);
                }
            }
            return new SuccessResult(Messages.Rentable);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult CheckRentableAndRental(Rental rental)
        {
            var rentability = IsRentable(rental.RentDate, rental.ReturnDate, rental.CarId);
            if (!rentability.Success)
            {
                return new ErrorResult(rentability.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.SuccessRental);
        }
    }
}
