using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class ViewShipmenDetail
    {
        public int Idshipment { get; set; }
        public string Noshipment { get; set; }
        public int? Idkapal { get; set; }
        public int? Idasal { get; set; }
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
        public int? Waiting1 { get; set; }
        public int? Waiting2 { get; set; }
        public int? Waiting3 { get; set; }
        public int? Waiting4 { get; set; }
        public int? Waiting5 { get; set; }
        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }
        public int? Idbantuan { get; set; }
        public string Prosesbantuan { get; set; }
        public int Idpelabuhanbantuan { get; set; }
        [Key]
        public int Iddetailshipment { get; set; }
        public int? Idproduk { get; set; }
        public List<ViewProduk> produk { get; set; }
        public int? Jumlah { get; set; }
        public int? Idsatuan { get; set; }
        public string ipt { get; set; }

        [NotMapped]
        public string[] idprodukapp { get; set; }

        public Pelabuhan IdasalNavigation { get; set; }
        public Kapal IdkapalNavigation { get; set; }
        public Pelabuhan IdpelabuhanbantuanNavigation { get; set; }
        public Pelabuhan IdtujuanNavigation { get; set; }
        public Produk IdprodukNavigation { get; set; }
        public Listsatuan IdsatuanNavigation { get; set; }
        public Shipment IdshipmentNavigation { get; set; }
    }

    public class ViewProduk
    {
        [Key]
        public int? produk { get; set; }
        public int? jumlah { get; set; }
    }
    
}
