using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //IServiceCollection bizim asp.net uygulamamızın kısacası apimizin servis bağımlılıklarını ekledimiz ayda raya girmesini istedimiz servisleri eklediğimiz koleksiyondur
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules)
            //Neyi geişletmek istiyorsak onu this ile veriyoruz 
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);

            }
            return ServiceTool.Create(serviceCollection);
        }

    }
    //IService collecitonu  addependency ile geinsletecegiz
    //neyi genisletmek istiyorsan this ile goster (parantezde virgulun solu)
    //virgulun sagina paramtre yazabilirisin simdi
    //polimorfism yapilmis-foreach ile  her bir mosul isin modulleri ekle
    //sonra da create ediyoz
    //CoreModule gibi başkamodellerideekleeybilmek için 

}