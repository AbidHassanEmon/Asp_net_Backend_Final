using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class CarModel
    {
        public int Car_id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Reg_year { get; set; }
        public int Mileage { get; set; }
        public int Rent { get; set; }
        public string Description { get; set; }
    }
}
