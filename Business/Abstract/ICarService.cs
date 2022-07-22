 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddTransactionalTest(Car car);//Uygulamalarda tutarsızlığı kontrol ettiğimiz yöntem örnek olarak benim ehsabımdan a kişisinin  hesabına 100 tl aktarıcam benim ehsabımdan 100 tl eksilecek şekilde update edeceğim a kişisinin hesabındanda 100 tl olarak artacak şekilde update edilmesi yani aynı süreçte iki adet veri tabanı işi var fakat benim hesabımdan giderken güncelledi ama a kişisinin ehsabına azarken sistem hata verdi bu durumda işlemi geri alması gerekiyor parayı iade etmesi gerekiyor yani tutarsızlık

    }
}
