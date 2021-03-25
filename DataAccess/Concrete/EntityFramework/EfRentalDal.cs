using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using Entities.DTO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarRecapContext>,IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (CarRecapContext context = new CarRecapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join br in context.Brands on car.Id equals br.Id
                             
                             select new RentalDetailDto
                             {
                                CarId=car.Id,
                                BrandName=br.Name,
                                FirstAndLastName=rental.FirstAndLastName,
                                RentDate=rental.RentDate,
                                ReturnDate=rental.ReturnDate,
                                TotalRentPrice = rental.TotalRentPrice
                             };
                return result.ToList();
            }
        }
    }
}
