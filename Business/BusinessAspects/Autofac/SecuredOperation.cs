using Business.Constants;
 using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//aspectsi , e bakarak  ayırıyor virgülle ayırıyor ve arraye atıyor
             _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();// burası bir aspect oldugu için buraya direk inject edemiyoruz o yüzden servicetoolu kullanıyoruz.

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();// O Anki kullanıcın claim rollerini bul bakayım diyor
            foreach (var role in _roles)//bu kullanıcının rollerini gez ve ilgili rol var ise methodu çalıştırmaya devam et
            {
                if (roleClaims.Contains(role))
                {
                    return;//eğer claim içerisinede ilgili rol varsa metodu çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied);//yoksa yetkiniz yok hatası mesajı ver
        }
    }
}