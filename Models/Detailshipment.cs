using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Detailshipment
    {
        public int Iddetailshipment { get; set; }
        public int? Idshipment { get; set; }
        public int? Idproduk { get; set; }
        public int? Jumlah { get; set; }
        public int? Idsatuan { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public Produk IdprodukNavigation { get; set; }
        public Listsatuan IdsatuanNavigation { get; set; }
        public Shipment IdshipmentNavigation { get; set; }
    }
}
