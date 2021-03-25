using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Core.DataAccess;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();

        List<AllCarDetailsDto> GetAllCarDetails(Expression<Func<AllCarDetailsDto, bool>> filter = null);

        CarDetailsDto GetOneCarDetail(int carId);

    }
}
