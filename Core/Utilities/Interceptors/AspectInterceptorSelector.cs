using Castle.DynamicProxy;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector//Burası methodun üstüne bakıyordu ve intercepterları yani aspectleri bulup çalıştırıyor
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            // classAttributes.Add(  new PerformanceAspect(5)); Bunu buraya böyle eklersek mevcutta ve ilerde ekleyeceğim bütün  methodlarda bu  çalışır ama bu nasıl oluyor ?
          //  classAttributes.Add(new CacheAspect());
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
