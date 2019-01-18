using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class UserDetails
    {
        [Required]
        [Display(Name = "Nama User")]
        public string Namauser { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string Akses { get; set; }
    }
}
