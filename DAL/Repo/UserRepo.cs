using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, int,bool>
    {
        Project_DBEntities db;

        public UserRepo(Project_DBEntities db)
        {
            this.db = db;
        }

        public bool Create(User obj)
        {
            db.Users.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Users.Remove(Get(id));
            db.SaveChanges();
            return true;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(s => s.User_id == id);
        }

        public bool Update(User obj)
        {
            var exist = db.Users.FirstOrDefault(x => x.User_id == obj.User_id);
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
