using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static Project_DBEntities db = new Project_DBEntities();
        public static IRepo<Car, int> CarDataAccess()
        {
            return new CarRepo(db);
        }
        public static IRepo<Rent, int> RentDataAccess()
        {
            return new RentRepo(db);
        }

        public static IRepo<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }
    }
}
