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
   public class AuthServices
    {
        public static TokenModel Authenticate(string uname, string pass)
        {
            var user = DataAccessFactory.AuthDataAccess().Authenticate(uname, pass);
            TokenModel t = null;
            if (user != null)
            {
                var key = GenToken();

                Token token = new Token();
                token.TokenKey = key;
                token.User_id = user.User_id;
                token.CreatedAt = DateTime.Now;
                token.Role = user.Role;

                var created_token = DataAccessFactory.TokenDataAccess().Create(token);

                t = new TokenModel()
                {
                    ID = created_token.ID,
                    TokenKey = created_token.TokenKey,
                    CreatedAt = created_token.CreatedAt,
                    User_id = created_token.User_id,
                    ExpiredAt = created_token.ExpiredAt,
                    Role= created_token.Role
                };

            }
            return t;
        }

        public static bool TokenValidity(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.ExpiredAt == null)
            {
                return true;
            }
            return false;

        }

        public static bool IsAdmin(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.Role == "Admin")
            {
                return true;
            }
            return false;
        }

        public static bool IsUser(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.Role == "User")
            {
                return true;
            }
            return false;
        }


        public static bool Logout(TokenModel tk)
        {
            var d_tk = DataAccessFactory.TokenDataAccess().Get(tk.TokenKey);
            d_tk.ExpiredAt = DateTime.Now;
            return DataAccessFactory.TokenDataAccess().Update(d_tk);
        }

        public static string GenToken()
        {
            Random res = new Random();
            String str = "abcdefghijklmnopqrstuvwxyz";
            int size = 40;
            String ran = "";
            for (int i = 0; i < size; i++)
            {
                int x = res.Next(26);
                ran = ran + str[x];
            }
            return ran;
        }
    }
}
