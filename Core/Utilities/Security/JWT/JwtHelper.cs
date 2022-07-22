using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//configuration webapideki  appsettings.jsondan okuyor
        private TokenOptions _tokenOptions;//apsettingeki okudugumuz değerleri burdaki nesneye aktarıyoruz
        private DateTime _accessTokenExpiration;//Değeri tarihe çeviriyoruz
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;                                               //
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//app settingsteki tokenoptions adlı kısmı get et, burayı al 
                                                                                         //ve tokenoptions adlı classa göre maple-ata tek tek tokenoptionsa ata yani  
                                                                                         //Microsoft.Extensions.Configuration.Binder(.net 5 te get hatasından dolayı yükelemk geeklis   )


        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//Bu token ne zaman bitecek  webapideki appsetting.jsondan alıyor
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//Tokeni oluştururken kendi bildiğimiz özel anahtarı oluşturma Artık elimizde birtane anahtar mevcut
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//Security key ve algoritmamızı belirlediğimiz nesnedir
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//Elimizdeki bilgileri kullanarak(TokenOptions,Kullanıcı bilgileri,signingCredentials bilgileri ve kullanıcıların roleri) kullanarak token oluşturuyoruz aşağıdaki methodda!
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();//elimizdeki tokeni handler vasıtasıyla yazıyoruz
            var token = jwtSecurityTokenHandler.WriteToken(jwt);// writetoken ile stringe çeviriyoruz

            return new AccessToken//ve tokeni döndürüyoruz
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)//ilgili bilgileri vererek Token oluşturma
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,//Eğer tokenin expires bilgisi şuandan önceyse geçersiz demek
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)//Kullanıcı bilgilerine göre Roller için claim listesi oluşturuyoz rol oluşturuyoruz
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(user.UserId.ToString());// bunlar Claimde yok extend olarak biz ekledik
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }

    }
}