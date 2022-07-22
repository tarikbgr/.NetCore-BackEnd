using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;//[PerformanceAspect(5)] buradaki 5 interval oluyor yani bu method çalışması 5 sn yi geçerse beni uyar 
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();//Methodun Önünde kronemetreyi çalıştırıyor
        }

        protected override void OnAfter(IInvocation invocation)//o ana kadar Geçen süreyi hesaplıyor 
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");//Burda direk consolalog olarak yazmışız istersekmail cart curt yollayabilirz
            }
            _stopwatch.Reset();
        }
    }
}