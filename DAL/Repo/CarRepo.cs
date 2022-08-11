using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CarRepo : IRepo<Car, int, bool>
    {
        Project_DBEntities db;

        public CarRepo(Project_DBEntities db)
        {
            this.db = db;
        }

        public bool Create(Car obj)
        {
            db.Cars.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Cars.Remove(Get(id));
            db.SaveChanges();
            return true;
        }

        public List<Car> Get()
        {
            return db.Cars.ToList();
        }

        public Car Get(int id)
        {
            return db.Cars.FirstOrDefault(s => s.Car_id == id);
        }

        public bool Update(Car obj)
        {
            var exist = db.Cars.FirstOrDefault(x => x.Car_id == obj.Car_id);
            if (exist != null)
            {
                db.Entry(exist).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
