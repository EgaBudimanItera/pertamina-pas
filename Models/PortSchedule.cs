using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class PortSchedule
    {
        [Key]
        public string Idshipment { get; set; }
        public string Noshipment { get; set; }
        public int? Idkapal { get; set; }
        public string NamaKapal { get; set; }
        public int? Idasal { get; set; }
        public string NamaAsalPelabuhan { get; set; }
        public int? Idtujuan { get; set; }
        public string Proses { get; set; }
        [Display(Name = "Arrival")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Arrival { get; set; }
        public DateTime? Berthed { get; set; }
        public DateTime? Comm { get; set; }
        public DateTime? Comp { get; set; }
        public DateTime? Unberthed { get; set; }
        public DateTime? Departure { get; set; }
       
        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }
        public int? Idbantuan { get; set; }
        public string Prosesbantuan { get; set; }
        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public string ipt { get; set; }

        
        

    }
}
