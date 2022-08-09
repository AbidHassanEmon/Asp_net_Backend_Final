using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
   public class RentModel
    {
        public int Rent_id { get; set; }
        public int Car_id { get; set; }
        public int User_id { get; set; }
        public string Pickup_time { get; set; }
        public string Return_time { get; set; }
        public int Total_fear { get; set; }
    }
}
