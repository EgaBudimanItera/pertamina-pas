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
        public string NamaTujuanPelabuhan { get; set; }
        public string Proses { get; set; }
        
        public string Arrival { get; set; }
        public string Berthed { get; set; }
        public string Comm { get; set; }
        public string Comp { get; set; }
        public string Unberthed { get; set; }
        public string Departure { get; set; }
       
        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }
        public int? Idbantuan { get; set; }
        public string Prosesbantuan { get; set; }
        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public string Ipt { get; set; }
    }
}
