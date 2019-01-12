using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Produk
    {
        public Produk()
        {
            Detailshipment = new HashSet<Detailshipment>();
            Stok = new HashSet<Stok>();
        }

        public int Idproduk { get; set; }
        public string Namaproduk { get; set; }
        public string Jenisproduk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public ICollection<Detailshipment> Detailshipment { get; set; }
        public ICollection<Stok> Stok { get; set; }
    }
}
