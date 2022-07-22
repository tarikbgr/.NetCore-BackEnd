using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);//genel bağımlılıkları yükleyecek-service collection alsın. bura core olduğu içintüm farklı projelerdeki bağımlılıklar yani sadece recapta cullanılacak injectionlar değil


    }
}