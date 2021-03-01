using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<AllCarDetailsDto>> GetAllCarDetails();
    }
}
