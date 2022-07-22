using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//params ile istediğinmiz kadar parametre gönderebiliriz.
        {
           
            foreach (var logic in logics)
            {
                if (!logic.Success)//parametre olarak gönderdiğimiz iş kurallarından başarısız olanları businesse gönderiyoruz bütün kuralları gez kurala uymayan varsa uymuyan kuralı döndür...
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
