﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<AllCarDetailsDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<AllCarDetailsDto>>(_carDal.GetAllCarDetails(),Messages.Listed);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }
        
        public IDataResult<List<Car>> GetAll()
        {
           return new ErrorDataResult<List<Car>>(_carDal.GetAll(),Messages.Maintenance); 
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<CarDetailsDto> GetOneCarDetail(int carId)
        {
            var carResult = _carDal.GetOneCarDetail(carId);
            return new SuccessDataResult<CarDetailsDto>(carResult, Messages.Listed); ;
        }


        public IDataResult<AllCarDetailsDto> GetCarAllInfo(int carId)
        {
            var carResult = _carDal.GetOneCarDetail(carId);
            var carImages = _carImageService.Get(carId);

            AllCarDetailsDto allCarDetailsDto = new AllCarDetailsDto
            {
                CarId = carResult.CarId,
                BrandName = carResult.BrandName,
                CarName = carResult.CarName,
                ColorName = carResult.ColorName,
                DailyPrice = carResult.DailyPrice,
                Description = carResult.Description,
                ModelYear = carResult.ModelYear,
                CarImages = carImages.Data
            };

            return new SuccessDataResult<AllCarDetailsDto>(allCarDetailsDto, Messages.Listed);

        }

        public IDataResult<List<AllCarDetailsDto>> GetByBrand(int brandId)
        {
            var result = _carDal.GetAllCarDetails(c => c.BrandId == brandId);
            return new SuccessDataResult<List<AllCarDetailsDto>>(result, Messages.Listed);
        }
        public IDataResult<List<AllCarDetailsDto>> GetByColor(int colorId)
        {
            var result = _carDal.GetAllCarDetails(c => c.ColorId == colorId);
            return new SuccessDataResult<List<AllCarDetailsDto>>(result, Messages.Listed);
        }
    }
}
