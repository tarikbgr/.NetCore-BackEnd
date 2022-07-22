using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje claslarını bağlamak  
    public class ReCapContext : DbContext //bu context sayesinde bulunduğumuz entity framework klasöründeki dallardaki kodların çoğu ortak alan olara efentitiryreposistorybase  e gidecek
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCap;Trusted_Connection=true");
        }
        //Hangi nesne hangi nesneye bağlanacak
        //aşağıda dbset ile yapıcaz
        //dbset içerisindeki bizimki
        //sağdaki veritabanındaki tablo adı
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
   
    }
}
