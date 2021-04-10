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
        IDataResult<List<AllCarDetailsDto>> GetAllCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<AllCarDetailsDto> GetCarAllInfo(int carId);
        IDataResult<List<AllCarDetailsDto>> GetByBrand(int brandId);
        IDataResult<List<AllCarDetailsDto>> GetByColor(int colorId);
        IDataResult<CarDetailsDto> GetOneCarDetail(int carId);
        IDataResult<List<AllCarDetailsDto>> GetByBrandAndColor(int colorId, int brandId);
    }
}
