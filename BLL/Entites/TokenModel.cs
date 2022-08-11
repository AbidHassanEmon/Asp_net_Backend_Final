using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
   public class TokenModel
    {
         public int ID { get; set; }
        public int User_id { get; set; }
        public string TokenKey { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> ExpiredAt { get; set; }
        public string Role { get; set; }
    }
}
