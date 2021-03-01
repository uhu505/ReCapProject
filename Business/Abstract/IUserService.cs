using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);

        IResult Delete(User user);

        IResult Update(User user);

        IDataResult<User> GetUsers(string email);

        IDataResult<List<User>> GetAll();

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMail(string email);

        IDataResult<User> GetById(int id);
    }
}