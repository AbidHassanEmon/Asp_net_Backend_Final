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
        public static IRepo<Car, int,bool> CarDataAccess()
        {
            return new CarRepo(db);
        }
        public static IRepo<Rent, int,bool> RentDataAccess()
        {
            return new RentRepo(db);
        }

        public static IRepo<User, int,bool> UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IAuth<User> AuthDataAccess()
        {
            return new AuthRepo(db);
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo(db);
        }
    }
}
