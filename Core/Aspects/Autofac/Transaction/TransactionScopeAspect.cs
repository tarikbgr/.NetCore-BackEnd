using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {


        // Deneme (Transaction: hatalı işlemde işlemin geri alınması) invocation method demek
        public override void Intercept(IInvocation invocation)
        {
            
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();//TransactionScopeAspect eklediğimiz  Methodumuzu çalıştırıyor
                    transactionScope.Complete();//vebitiriyor
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();//hata varsa geri alıyor gibi kısaca 
                    throw;
                }
            }
            
        }
    }
}