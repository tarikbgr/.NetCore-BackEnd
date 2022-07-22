using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)//claimsprincipal bir kişinin jwt tokende gelen claimlerine ulaşmak için gerekli olan sınıf
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();//ilgili claimtype göre getiriyor
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)//direk rolleri getiriyor
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}