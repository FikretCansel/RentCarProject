using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;

        public InMemoryCarDal()
        {
            cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=2,Description="hızlı araba",DailyPrice=500,ModelYear=1 }
            };
        }

        public void Add(Car car)
        {
            cars.Add(car);
            Console.WriteLine(car.Description + "eklendi");
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault(c => c.Id == car.Id);
            cars.Remove(carToDelete);
            Console.WriteLine(carToDelete.Description + "silindi");
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            Console.WriteLine(carToUpdate.Description+"olarak güncellendi.");
        }
        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<AllCarDetailsDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public AllCarDetailsDto GetOneCarDetail(Car carEntity)
        {
            throw new NotImplementedException();
        }

        public AllCarDetailsDto GetOneCarDetail(int carId)
        {
            throw new NotImplementedException();
        }

        public List<AllCarDetailsDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<AllCarDetailsDto> GetAllCarDetails(Expression<Func<AllCarDetailsDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        CarDetailsDto ICarDal.GetOneCarDetail(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
