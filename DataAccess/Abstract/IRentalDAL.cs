using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDAL : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
    }
}