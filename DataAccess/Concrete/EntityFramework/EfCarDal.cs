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
        public List<AllCarDetailsDto> GetAllCarDetails(Expression<Func<AllCarDetailsDto, bool>> filter = null)
        {
                using (CarRecapContext context = new CarRecapContext())
                {
                    var result = from car in context.Cars
                                 join br in context.Brands on car.BrandId equals br.Id
                                 join cl in context.Colors on car.ColorId equals cl.Id
                                 select new AllCarDetailsDto
                                 {
                                     CarId = car.Id,
                                     BrandId=car.BrandId,
                                     CarName = car.Name,
                                     BrandName = br.Name,
                                     ColorName = cl.Name,
                                     DailyPrice = car.DailyPrice,
                                     ModelYear = car.ModelYear,
                                     Description = car.Description
                                 };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }    

        public AllCarDetailsDto GetOneCarDetail(int carId)
        {
            using (CarRecapContext context = new CarRecapContext())
            {
                var result = from car in context.Cars
                             join br in context.Brands on car.BrandId equals br.Id
                             join cl in
                             context.Colors on car.ColorId equals cl.Id
                             where carId == car.Id
                             select new AllCarDetailsDto
                             {
                                 CarId = car.Id,
                                 CarName = car.Name,
                                 BrandName = br.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
