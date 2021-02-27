using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);

        IResult Delete(Rental rental);

        IResult Update(Rental rental);

        IDataResult<List<Rental>> GetRentals();

        IDataResult<Rental> GetById(int id);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}