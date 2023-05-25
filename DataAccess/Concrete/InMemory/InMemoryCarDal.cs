using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()//constractor oluşturma bloğu. bellekte referans aldığında çalışacak blok
        {
            _cars = new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=2,DailPrice=1250,ModelYear=2023,Description="TOGG YERLİ ELEKTRİKLİ ARAÇ" },
            new Car{CarId=2,BrandId=2,ColorId=2,DailPrice=1000,ModelYear=2021,Description="TEK KAPI SPOR ARABA"},
            new Car{CarId=3,BrandId=2,ColorId=1,DailPrice=750,ModelYear=2015,Description="VIP 13 KİŞİLİK ŞÖFÖRLÜ ARAÇ"},
            new Car{CarId=4,BrandId=2,ColorId=1,DailPrice=900,ModelYear=2018,Description="SUV ARAÇ" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
           
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public void Update(Car car)
        {
            //gönderdiğim ürün id sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId= car.ColorId;
            carToUpdate.ModelYear= car.ModelYear;
            carToUpdate.DailPrice= car.DailPrice;
            
        }
    }
}
