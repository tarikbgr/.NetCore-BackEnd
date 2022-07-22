using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
            //IValidator örnek olarak prodactvalidatör demek fluentvalidationdaki kısımlar  object entitiy de doğrulanack class demek
        {
            var context = new ValidationContext<object>(entity);

            var result = validator.Validate(context);//valide ederek doğru olup olmadıgına baktık
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
        //    var context = new ValidationContext<Car>(car); yukardaki kodun eski hali 
        //    CarValidator carValidator = new CarValidator();
        //    var result = carValidator.Validate(context);
        //        if (!result.IsValid)
        //        {
        //            throw new ValidationException(result.Errors);
        //}
    }
}
