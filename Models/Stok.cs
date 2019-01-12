using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Stok
    {
        public int Idstock { get; set; }
        public int? Idlistpelabuhan { get; set; }
        public int? Idproduk { get; set; }
        public int? Pumpable { get; set; }
        public int? Dot { get; set; }
        public int? Safestok { get; set; }
        public int? Deadstok { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public Pelabuhan IdlistpelabuhanNavigation { get; set; }
        public Produk IdprodukNavigation { get; set; }
    }
}
