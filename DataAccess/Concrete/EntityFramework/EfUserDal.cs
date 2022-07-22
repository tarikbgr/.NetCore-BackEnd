using Core.DataAcces.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims//küçük harfle başlayan  büyüğü temsil ediyor
                             join userOperationClaim in context.UserOperationClaims// operationclaimlerle useropertaionclaimlere join atıyor ve onlar içerisinde id si benim gönderdiğim usera eşit olan id yi buluyor ve operationclaimolarak return ediyor  
                                 on operationClaim.Id equals userOperationClaim.Id
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
 