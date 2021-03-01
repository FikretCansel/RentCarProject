using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();

        List<AllCarDetailsDto> GetAllCarDetails();
    }
}
