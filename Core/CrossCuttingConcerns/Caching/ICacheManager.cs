using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);//Aşağıdaki liste döndürür bu da tek data döndürür generic method 
        void Add(string key, object value, int duration);//object : gelecek data duration: bu cachede ne akdar duracak
        object Get(string key);
        bool IsAdd(string key);//Cachede varmı varsa cacheden getir yoksa veritabanından
        void Remove(string key);//Cacheden uçurma
        void RemoveByPattern(string pattern);//Başı sonunu önemli değil içinde car olanlar ayda brand olanlar gibi
    }
}
