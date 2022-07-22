using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;//Bir iş sınıfı başka sınıfı nevlemez constractırını olusturur Dependency İnjection soyut nesneyle bağlantı kurarız
        IBrandService _brandService;
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;// başka bir manageri kullanmamız gerekirse onun interfacesini kullanırız. aşağıdaki fonksiyona bak anlarsın.. bir entitiymanager kendisi haric başka bir manageri encekte edemez
        }

        [ValidationAspect(typeof(CarValidator))] //Doğrulama yapıyoruz
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IcarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOFBrandIdCorrect(car.BrandId), CheckIfCarName(car.Description));// burada uymayan varsa resulta gidiyor
                                                                                                                              // CheckIfCarName(car.Description),CheckIfBrandLimitExceded() 
            if (result != null)//eğer kurala uymayan bid durum varsa resultu dönder
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            //using (TransactionScope scope = new TransactionScope())  Bu kötü kod biz bunu aspect olarak yazıcaz
            //{
            //    try
            //    {
            //        Add(car);
            //        if (car.DailyPrice<10)
            //        {
            //            throw new Exception("Hata");
            //        }
            //        Add(car);
            //        scope.Complete();//eğer başarılı olursa scopu complete et yani bitir
            //    }
            //    catch (Exception)
            //    {

            //        scope.Dispose();//eğer başarısız olursa Dispose yap
            //    }
            //}
            //return null;
            //Burası Denemek için örnek
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("Hata");
            }
            Add(car);
            return new SuccessResult("dd");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetails);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        [CacheRemoveAspect("IcarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckIfCarCountOFBrandIdCorrect(int brandId)
        {
            var result = _carDal.GetAll(p => p.BrandId == brandId).Count;//gelen id deki araba sayısına bakıyor
            if (result < 15)
            {

                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarCountOFBrandId);

        }
        //private IResult CheckIfBrandLimitExceded()//burada brandmanager la ilgili kural yazdığımız için servisini lkullandık başka servislerin kurallarını onun amnagerine yazmak daha sağlıklı heralde
        //{
        //    var result = _brandService.GetAll();
        //    if (result.Data.Count > 15)
        //    {
        //        return new ErrorResult();
        //    }
        //    return new SuccessResult();
        // }
        private IResult CheckIfCarName(string carName)
        {
            var result = _carDal.GetAll(p => p.Description == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();

        }
    }
}
