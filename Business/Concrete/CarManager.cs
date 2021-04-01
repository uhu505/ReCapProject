using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDAL _carDAL;

        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDAL.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDAL.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDAL.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.Listed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDAL.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetailDtos());
        }

        public IDataResult<List<CarDetailDto>> GetCarByIdDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetailDtos(filter: car => car.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetailDtos(filter: car => car.BrandId == brandId && car.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarByDetails(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetailDtos(filter: car => car.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetailDtos(filter: car => car.ColorId == colorId));
        }
    }
}