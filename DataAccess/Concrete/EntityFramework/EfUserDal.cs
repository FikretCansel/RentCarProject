using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,CarRecapContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRecapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
        public void UpdateFullName(User user)
        {
            using (var context = new CarRecapContext())
            {
                context.Users.Attach(user);
                context.Entry(user).Property(x => x.FirstName).IsModified = true;
                context.Entry(user).Property(x => x.LastName).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
