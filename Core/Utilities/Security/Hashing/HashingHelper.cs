using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {

        //hash olusturma islemi
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)//verdiğimiz passworda göre has ve salt değerini oluşuruyor
        {
           
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//bu algoritmaya göreoluşturuyor
            {
                passwordSalt = hmac.Key;//algoritmanın o an oluşturduğu key değeridir
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//hash hesaplama


            }
        }
        //kullanıcı sisteme tekrar girmeye çalışıyor bu password hashlenmiş
        //burada hash doğrulama işlemi yapıyorum
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//kullanıcının sisteme girdiği parolayı tekrardan hashliyoruz daha sonra db deki hashı ve girilen hashı karşılaştırıyoruz doğruysa true yanlışsa false
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {//doğrulama yapacaz passwordsaltı ister kkey olarak
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //hashin değerlerini kkıyaslamak amacıyla
                for (int i = 0; i < computedHash.Length; i++)//eğerki benim hesaplananhasımın i ninci deeğeri veritabanından gönderilen hasha eşit değilse false
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }
            

        }
    }
}