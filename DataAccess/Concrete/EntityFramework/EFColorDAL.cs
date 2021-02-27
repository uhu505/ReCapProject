using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFColorDAL : EFEntityRepositoryBase<Color, ReCapDbContext>, IColorDAL
    {
    }
}