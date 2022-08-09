using BLL.Entites;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CarServices
    {
        public static List<CarModel> Get()
        {
            var data = DataAccessFactory.CarDataAccess().Get();
            var cars = new List<CarModel>();
            foreach (var item in data)
            {
                var s = new CarModel()
                {
                    Car_id = item.Car_id,
                    Name = item.Name,
                    Model = item.Model,
                    Reg_year = item.Reg_year,
                    Rent=item.Rent,
                    Mileage=item.Mileage,
                    Description=item.Description
                };
                cars.Add(s);
            }
            return cars;
        }

        public static CarModel Get(int id)
        {
            var item = DataAccessFactory.CarDataAccess().Get(id);
            var s = new CarModel()
            {
                Car_id = item.Car_id,
                Name = item.Name,
                Model = item.Model,
                Reg_year = item.Reg_year,
                Rent = item.Rent,
                Mileage = item.Mileage,
                Description = item.Description
            };
            return s;
        }

        public static bool Create(CarModel item)
        {
            var car = new Car()
            {
                Car_id = item.Car_id,
                Name = item.Name,
                Model = item.Model,
                Reg_year = item.Reg_year,
                Rent = item.Rent,
                Mileage = item.Mileage,
                Description = item.Description
            };
            return DataAccessFactory.CarDataAccess().Create(car);
        }

        public static bool Update(CarModel item)
        {
            var car = new Car()
            {
                Car_id = item.Car_id,
                Name = item.Name,
                Model = item.Model,
                Reg_year = item.Reg_year,
                Rent = item.Rent,
                Mileage = item.Mileage,
                Description = item.Description
            };
            return DataAccessFactory.CarDataAccess().Update(car);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CarDataAccess().Delete(id);
        }

    }
}
