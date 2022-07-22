using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarManager _carManager = new CarManager(new EfCarDal());
            ////var result = _carManager.GetCarDetails();
            ////if (result.Success)
            ////{
            ////    foreach (var car in result.Data)
            ////    {
            ////        Console.WriteLine(result.Message);
            ////    }
            ////}

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.Add(new Rental
            //{
            //    CarId = 5,
            //    CustomerId = 1,
            //    //RentDate = DateTime.Now,
            //    ReturnDate=DateTime.Now
             

            //});
            //if (result.Success == true)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}


            //var result = _carManager.Add(new Car { 
            //BrandId=4,
            //ColorId=4,
            //DailyPrice=150,
            //Description="o",
            //ModelYear=1520
            //});
            //if (result.Success==true)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine(item.ColorName);
            //}


        }
    }
}
