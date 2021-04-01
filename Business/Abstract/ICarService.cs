using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);

        IResult Delete(Car car);

        IResult Update(Car car);

        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int id);

        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);

        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarByDetails(int id);

        IDataResult<List<CarDetailDto>> GetCarByIdDetails(int carId);

        IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId, int colorId);
    }
}