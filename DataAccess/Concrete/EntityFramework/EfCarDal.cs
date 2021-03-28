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
                             join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandId=c.BrandId,
                                 BrandName = b.Name,
                                 ColorId=c.ColorId,
                                 ColorName=co.Name,
                                 CarName=c.Name,
                                 DailyPrice=c.DailyPrice,
                                 ModelYear=c.ModelYear,
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
                                     ColorId = car.ColorId,
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

        public CarDetailsDto GetOneCarDetail(int carId)
        {
            using (CarRecapContext context = new CarRecapContext())
            {
                var result = from car in context.Cars
                             join br in context.Brands on car.BrandId equals br.Id
                             join cl in
                             context.Colors on car.ColorId equals cl.Id
                             where carId == car.Id
                             select new CarDetailsDto
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
