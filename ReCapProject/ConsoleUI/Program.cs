using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest1();
            //CarTest2();
            //CarGetAllDetailsTest();
            //CarTest3();
            RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager manager = new RentalManager(new EfRentalDal());
            Rental rental4 = new Rental { CustomerId = 2, RentDate = "11-02-2021", CarId = 2, ReturnDate = null };
            var result4 = manager.Add(rental4);
            Console.WriteLine("2 numaralı araç kiralandı");

            Rental rental1 = new Rental { CustomerId = 2, RentDate = "11-02-2020", CarId = 2, ReturnDate = "22-06-2020" };
            var result = manager.Add(rental1);
            Console.WriteLine("2 numaralı araç tekrar kiralanmaya çalışıldı");
            Console.WriteLine(result.Message);


            foreach (var item in manager.GetAll().Data)
            {
                Console.WriteLine(item.CarId + "----" + item.CustomerId + "----" + item.RentDate);
            }
            Rental rental2 = new Rental { Id = 2, CustomerId = 2, RentDate = "11-02-2020", CarId = 2, ReturnDate = "25-07-2020" };
            var result2 = manager.Update(rental2);
            Console.WriteLine("2 numaralı araç iade edildi");
            Console.WriteLine(result2.Message);
            var result3 = manager.Add(rental1);
            Console.WriteLine("2 numaralı araç tekrar kiralandı");
            Console.WriteLine(result3.Message);
        }

        private static void CarTest3()
        {
            CarManager manager = new CarManager(new EfCarDal());
            var result = manager.GetAll();
            if (manager.GetAll().Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAllDetailsTest()
        {
            CarManager manager = new CarManager(new EfCarDal());
            Console.WriteLine("CarId----- Marka-----Renk------Fiyat");
            foreach (var item in manager.GetAllCarDetails().Data)
            {
                Console.WriteLine($"---{item.CarId}-----{item.BrandName}-----{item.ColorName}-----{item.DailyPrice}");
            }
        }

        private static void CarTest2()
        {
            CarManager manager = new CarManager(new EfCarDal());
            Console.WriteLine("CarId----- Marka-----Açıklama------");
            foreach (var item in manager.GetCarDetails().Data)
            {
                Console.WriteLine($"---{item.CarId}-----{item.BrandName}-----{item.Description}");
            }
        }

        private static void CarTest1()
        {
            CarManager ss = new CarManager(new EfCarDal());
            Car car1 = new Car { BrandId = 2, ColorId = 3, DailyPrice = 450, Description = "toyata", ModelYear = 1 };
            Car updatecar = new Car { BrandId = 1, ColorId = 2, DailyPrice = 450, Description = "ferrari", ModelYear = 1 };
            ss.Add(updatecar);
            foreach (var item in ss.GetAll().Data)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
