using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
   public class TokenModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public string TokenKey { get; set; }
        [Required]
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> ExpiredAt { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
