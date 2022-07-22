using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public interface ITokenHelper
    {
        //User kullanıcı bilgisine ve rollerine  göre token üretecek 
        //token içeriisne hangi claimleri yetkileri koyalım , bunlarda claim listesinden gelecek

        //api siteminde kullanıcı adı şifresi girildi
        //burada eğer doğruysa ilgili veritabanına gidicek ve bu kullanıcının
        //claimlerini bulucak,jwt üreticek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
