using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRecapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRecapContext context=new CarRecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
        public List<AllCarDetailsDto> GetAllCarDetails()
        {
            using (CarRecapContext context=new CarRecapContext())
            {
                var result = from car in context.Cars join br in context.Brands on car.Id equals br.Id join cl in
                    context.Colors on car.Id equals cl.Id
                             select new AllCarDetailsDto
                             {
                                 CarId = car.Id,
                                 BrandName = br.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
