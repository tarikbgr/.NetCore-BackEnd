using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcces
{
    //Generic Constraint
    //IEntity:IEntity olabilir veya IEntityi implemente eden bir nesne olabilir
    //İnterface ler nevlenemediği için Ientitiy yazamıyoruz
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       

    }
}
