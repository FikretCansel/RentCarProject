using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(e => e.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateEmail(User user)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateFullName(User user)
        {
            _userDal.UpdateFullName(user);
            return new SuccessResult(Messages.Updated);
        }

        public IResult UpdatePassword(User user)
        {
            throw new NotImplementedException();
        }

    }
}
