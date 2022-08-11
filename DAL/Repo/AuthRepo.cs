using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AuthRepo : IAuth<User>
    {
        Project_DBEntities db;

        public AuthRepo(Project_DBEntities db)
        {
            this.db = db;
        }

        public User Authenticate(string username, string password)
        {
            return db.Users.FirstOrDefault(u => u.User_name.Equals(username)
            && u.Password.Equals(password));
        }
    }
}
