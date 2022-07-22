using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal: EfEntityRepositoryBase<Brand,ReCapContext>,IBrandDal
    {
        //IBrandDalı implement etemiz lazım ama biz generic yaptımız için diyoruzki EfEntitiyRepositroyBasade var zaten oraya brand ve contexti yolla
    }
}
