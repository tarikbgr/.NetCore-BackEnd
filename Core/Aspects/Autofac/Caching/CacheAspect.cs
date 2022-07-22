using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception//Aspect yapmamızın endeni methodun içindeki kod karmaşıklıklarını azaltmak
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//{invocation.Method.Name}:Methodun ismini buluyoruz... {invocation.Method.ReflectedType.FullName}= namespace+classın ismini verir Northwind.Business.IProductserecixe.GetAll
            var arguments = invocation.Arguments.ToList();//Methodun parametrelerini listeye çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//parametreleri tek tek ekliyoruz  Northwind.Business.IProductserecixe.GetAll(Örnek) parametrelerin arasına vşrgül koy parametre yoksa null
            if (_cacheManager.IsAdd(key))//Git bak abaklım bellekte böyle bi cache anahtarı var mı 
            {
                invocation.ReturnValue = _cacheManager.Get(key);//eğer varsa methodu çalıştırma direk getir
                return; //cachedeki datayı getirdemek
            }
            invocation.Proceed();//yoksa oradaki methodu çalıştır yani örnek carmanagerdeki getall methodunun içindekini çalıştırıyor intercepter bu demek
            _cacheManager.Add(key, invocation.ReturnValue, _duration);// veritabanına git ve cacheye ekle
            //kısaca bizim çalıştırıdıgımız methodun mapespaceismi parametrelerine göre key oluşturuyor eğer bu key daha önce varsa direk cacheden al yoksa veritabanından al  ve cache ekle
        }
    }
}