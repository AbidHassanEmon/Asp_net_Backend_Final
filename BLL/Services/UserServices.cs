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
    public class UserServices
    {
        public static List<UserModel> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var users = new List<UserModel>();
            foreach (var item in data)
            {
                var s = new UserModel()
                {
                    User_id=item.User_id,
                    Name=item.Name,
                    Email=item.Email,
                    Dob=item.Dob,
                    Address=item.Address,
                    User_name = item.User_name,
                    Lisence_no=item.Lisence_no,
                    Password=item.Password,
                    Role=item.Role,
                    Otp=item.Otp,
                    Otp_expired=item.Otp_expired
                };
                users.Add(s);
            }
            return users;
        }

        public static UserModel Get(int id)
        {
            var item = DataAccessFactory.UserDataAccess().Get(id);
            var s = new UserModel()
            {
                User_id = item.User_id,
                Name = item.Name,
                Email = item.Email,
                Dob = item.Dob,
                Address = item.Address,
                User_name = item.User_name,
                Lisence_no = item.Lisence_no,
                Password = item.Password,
                Role = item.Role,
                Otp = item.Otp,
                Otp_expired = item.Otp_expired
            };
            return s;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }


        public static bool Create(UserModel item)
        {
            var s = new User()
            {
                User_id = item.User_id,
                Name = item.Name,
                Email = item.Email,
                Dob = item.Dob,
                Address = item.Address,
                User_name = item.User_name,
                Lisence_no = item.Lisence_no,
                Password = item.Password,
                Role = item.Role,
                Otp = item.Otp,
                Otp_expired = item.Otp_expired
            };
            return DataAccessFactory.UserDataAccess().Create(s);
        }

        public static bool Create(UserAdminModel item)
        {
            var s = new User()
            {
                User_id = item.User_id,
                Name = item.Name,
                Email = item.Email,
                Dob = item.Dob,
                Address = item.Address,
                User_name = item.User_name,
                Lisence_no = item.Lisence_no,
                Password = item.Password,
                Role = item.Role,
                Otp = item.Otp,
                Otp_expired = item.Otp_expired
            };
            return DataAccessFactory.UserDataAccess().Create(s);
        }
        public static bool UpdateProfile(UserPrifileUpdate item)
        {
            var user = DataAccessFactory.UserDataAccess().Get(item.User_id);
            user.User_id = item.User_id;
            user.Name = item.Name;
            user.Address = item.Address;
            user.Dob = item.Dob;
            user.Lisence_no = item.Lisence_no;
            user.Email = item.Email;

            var s = new User()
            {
                User_id = user.User_id,
                Name = user.Name,
                Email = user.Email,
                Dob = user.Dob,
                Address = user.Address,
                User_name = user.User_name,
                Lisence_no = user.Lisence_no,
                Password = user.Password,
                Role = user.Role,
                Otp = user.Otp,
                Otp_expired = user.Otp_expired
            };

            return DataAccessFactory.UserDataAccess().Update(s);
        }

        public static bool UpdatePassword(UserChangePassword item)
        {
            var user = DataAccessFactory.UserDataAccess().Get(item.User_id);
            if (user.Password == item.Password && item.NPassword == item.NNPassword)
            {
                user.Password = item.NPassword;
            }
            
            var s = new User()
            {
                User_id = user.User_id,
                Name = user.Name,
                Email = user.Email,
                Dob = user.Dob,
                Address = user.Address,
                User_name = user.User_name,
                Lisence_no = user.Lisence_no,
                Password = user.Password,
                Role = user.Role,
                Otp = user.Otp,
                Otp_expired = user.Otp_expired
            };

            return DataAccessFactory.UserDataAccess().Update(s);
        }
    }
}
