using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class CarModel
    {
        public int Car_id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Reg_year { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int Rent { get; set; }
        public string Description { get; set; }
    }
}
