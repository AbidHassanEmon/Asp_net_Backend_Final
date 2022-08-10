using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class OTPSubmit
    {
        
        public int Otp { get; set; }
        public int User_id { get; set; }
        public string Password { get; set; }
        public string NPassword { get; set; }
    }
}
