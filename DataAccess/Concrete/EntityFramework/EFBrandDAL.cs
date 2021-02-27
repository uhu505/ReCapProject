using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDAL : EFEntityRepositoryBase<Brand, ReCapDbContext>, IBrandDAL
    {
    }
}