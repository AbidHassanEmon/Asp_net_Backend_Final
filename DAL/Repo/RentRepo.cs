using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class RentRepo : IRepo<Rent, int,bool>
    {
        Project_DBEntities db;

        public RentRepo(Project_DBEntities db)
        {
            this.db = db;
        }

        public bool Create(Rent obj)
        {
            db.Rents.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Rents.Remove(Get(id));
            db.SaveChanges();
            return true;
        }

        public List<Rent> Get()
        {
            return db.Rents.ToList();
        }

        public Rent Get(int id)
        {
            return db.Rents.FirstOrDefault(s => s.Rent_id == id);
        }

        public bool Update(Rent obj)
        {
            var exist = db.Rents.FirstOrDefault(x => x.Rent_id == obj.Rent_id);
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
