using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDAL : IEntityRepository<User>
    {
    }
}