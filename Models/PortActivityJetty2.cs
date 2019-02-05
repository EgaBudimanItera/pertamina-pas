using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class PortActivityJetty2
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
        public int waiting1 { get; set; }
        public int waiting2 { get; set; }
        public int waiting3 { get; set; }
        public int waiting4 { get; set; }
        public int waiting5 { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? Arrival { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Berthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comm { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comp { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Unberthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public string Ipt { get; set; }

        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }
        public int? Idbantuan { get; set; }
        public string Prosesbantuan { get; set; }
        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public int JumlahProduk { get; set; }
    }
}
