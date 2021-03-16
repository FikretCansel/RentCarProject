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
                             join user in context.Users on rental.CustomerId equals user.Id
                             
                             select new RentalDetailDto
                             {
                                BrandName=br.Name,
                                FirstName=user.FirstName,
                                LastName=user.LastName,
                                RentDate=rental.RentDate,
                                ReturnDate=rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
