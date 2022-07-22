using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions//bunlar helper claslar
    {
        public string Audience { get; set; }//tokenin kullanıcı kitlesi
        public string Issuer { get; set; }//imzalayan kişi
        public int AccessTokenExpiration { get; set; } 
        public string SecurityKey { get; set; }
    }
}