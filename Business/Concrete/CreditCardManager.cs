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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<List<CreditCard>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c=>c.UserId==userId), Messages.Listed);
        }
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), Messages.Listed);
        }
        public IResult Update(CreditCard color)
        {
            _creditCardDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
