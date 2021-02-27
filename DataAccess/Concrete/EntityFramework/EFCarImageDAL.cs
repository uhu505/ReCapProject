using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFCarImageDAL : EFEntityRepositoryBase<CarImage, ReCapDbContext>, ICarImageDAL
    {
    }
}