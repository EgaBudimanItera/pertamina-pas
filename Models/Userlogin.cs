using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Userlogin
    {
        public int Iduserlogin { get; set; }
        public string Namauser { get; set; }
        public string Password { get; set; }
        public string Akses { get; set; }
        public int? IdPelabuhan { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public Pelabuhan IdPelabuhanNavigation { get; set; }
    }
}
