using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception//validationaspect bizzim aspectimiz aspect demek emthodun başında sonunda çalışcak gibi şeyler
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//bana bir validatortype ver 
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderdiğin validatortypı doğruluyor yani ıvalidator mü diye bakıyopr
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//çalışma naında bize instance oluşturuyor yani newliyor yukarda verdiğimiz validatortypeyi newliyoor = new carvaldiator() gibi
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//örnek: carvalidatörün base ne git ve generic parametlerine bak ilkini yakala yani product. Çünki bi üstte neyi newleyeceğimizi neyi validate  etceğimizi söylüyoruz.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// methodun argumanlarını(parametrelerini gez) oradaki bi type benim entityTyp türündeyse onu aşşağıda valide et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
