using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(User User)
        {
            _userDAL.Add(User);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User User)
        {
            _userDAL.Delete(User);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User User)
        {
            _userDAL.Update(User);
            return new SuccessResult();
        }

        public IDataResult<User> GetUsers(string email)
        {
            var check = _userDAL.Get(filter: user => user.Email == email);
            if (check == null)
            {
                return new ErrorDataResult<User>(data: check);
            }

            return new SuccessDataResult<User>(data: check);
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(data: _userDAL.Get(filter: user => user.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDAL.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var check = _userDAL.Get(filter: user => user.Email == email);
            if (check == null)
            {
                return new ErrorDataResult<User>(check);
            }

            return new SuccessDataResult<User>(check);
        }
    }
}