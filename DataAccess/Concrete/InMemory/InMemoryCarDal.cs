using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
         List<Car> _cars;

         public InMemoryCarDal()
         {
             _cars = new List<Car>
             {
                 new Car {CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 150, ModelYear = 2000, Description = "Marea"},
                 new Car {CarId = 2, BrandId = 2, ColorId = 2, DailyPrice = 150, ModelYear = 2010, Description = "Jetta"},
                 new Car {CarId = 3, BrandId = 3, ColorId = 2, DailyPrice = 150, ModelYear = 2008, Description = "Golf"},
                 new Car {CarId = 4, BrandId = 4, ColorId = 3, DailyPrice = 150, ModelYear = 2005, Description = "Laguna"},
             };
         }

         public List<Car> GetAll()
         {
             return _cars;
         }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün id sine sahip olan listedeki ürünü bul demek (yani heap daki referans numaralarını  buluyor  )
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
