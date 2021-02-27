using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);

        IResult Delete(User user);

        IResult Update(User user);

        IDataResult<List<User>> GetUsers();

        IDataResult<User> GetById(int id);
    }
}