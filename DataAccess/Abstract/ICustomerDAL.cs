using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerDAL : IEntityRepository<Customer>
    {
    }
}