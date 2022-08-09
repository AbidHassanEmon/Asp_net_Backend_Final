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
   public class RentServices
    {
        public static List<RentModel> Get()
        {
            var data = DataAccessFactory.RentDataAccess().Get();
            var Rents = new List<RentModel>();
            foreach (var item in data)
            {
                var s = new RentModel()
                {
                    Rent_id=item.Rent_id,
                    Car_id=item.Car_id,
                    User_id=item.User_id,
                    Pickup_time=item.Pickup_time,
                    Return_time=item.Return_time,
                    Total_fear=item.Total_fear
                };
                Rents.Add(s);
            }
            return Rents;
        }

        public static RentModel Get(int id)
        {
            var item = DataAccessFactory.RentDataAccess().Get(id);
            var s = new RentModel()
            {
                Rent_id = item.Rent_id,
                Car_id = item.Car_id,
                User_id = item.User_id,
                Pickup_time = item.Pickup_time,
                Return_time = item.Return_time,
                Total_fear = item.Total_fear
            };
            return s;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RentDataAccess().Delete(id);
        }

        public static bool Update(RentModel item)
        {
            var s = new Rent()
            {
                Rent_id = item.Rent_id,
                Car_id = item.Car_id,
                User_id = item.User_id,
                Pickup_time = item.Pickup_time,
                Return_time = item.Return_time,
                Total_fear = item.Total_fear
            };
            return DataAccessFactory.RentDataAccess().Update(s);
        }

        public static bool Create(RentModel item)
        {
            var Rent = DataAccessFactory.CarDataAccess().Get(item.Car_id).Rent;

            var s = Convert.ToDateTime(item.Pickup_time);
            var Re = Convert.ToDateTime(item.Return_time);

            var Day = Convert.ToInt32(Re.Subtract(s).TotalDays);

            int Total = Rent * Day;

            var rent = new Rent()
            {
                Rent_id = item.Rent_id,
                Car_id = item.Car_id,
                User_id = item.User_id,
                Pickup_time = item.Pickup_time,
                Return_time = item.Return_time,
                Total_fear = Total
            };
            return DataAccessFactory.RentDataAccess().Create(rent);
        }
    }
}
