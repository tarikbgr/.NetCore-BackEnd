using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)//herhangi bir interfacein karşılıgını bu tool sayesinde alabiliriz injectionlarını yani
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}