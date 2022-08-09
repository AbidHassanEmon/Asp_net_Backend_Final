using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
   public class UserPrifileUpdate
    {
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public System.DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Lisence_no { get; set; }
    }
}
