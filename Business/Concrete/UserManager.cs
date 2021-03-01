using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using Business.Constants;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User User)
        {
            _userDAL.Add(User);
            return new SuccessResult();
        }

        public IResult Delete(User User)
        {
            _userDAL.Delete(User);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User User)
        {
            _userDAL.Update(User);
            return new SuccessResult();
        }

        public IDataResult<User> GetUsers(string email)
        {
            return new SuccessDataResult<User>(_userDAL.Get(c => c.Email == email));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDAL.Get(c => c.Id == id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDAL.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var get = _userDAL.GetAll(u => u.Email == email);
            var emailCheck = get.Count;

            return emailCheck > 0 ? null : new ErrorDataResult<User>();
        }
    }
}