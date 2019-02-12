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
        [Required(ErrorMessage = "Pilih Kapal Yang Akan Digunakan")]
        public int? Idkapal { get; set; }
        [Required]
        public int? Idasal { get; set; }
        [Required]
        public int? Idtujuan { get; set; }
        [Required]
        public string Proses { get; set; }
        [Required]
        [Display(Name = "Arrival")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Arrival { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Berthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Comm { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Comp { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Unberthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Departure { get; set; }
        public int? Waiting1 { get; set; }
        public int? Waiting2 { get; set; }
        public int? Waiting3 { get; set; }
        public int? Waiting4 { get; set; }
        public int? Waiting5 { get; set; }
        public string Status { get; set; }
        public int? Antrian { get; set; }
        [Required]
        public int? Nojetty { get; set; }
        public int? Idbantuan { get; set; }
        public string Prosesbantuan { get; set; }
        public int Idpelabuhanbantuan { get; set; }
        [Key]
        public int Iddetailshipment { get; set; }

        public int? Idproduk { get; set; }
        [Required]
        public List<ViewProduk> produk { get; set; }
        public int? Jumlah { get; set; }
        public int? Idsatuan { get; set; }
        public int? UpdateAntrian { get; set; }
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

        public List<IsiShipment> Isi { get; set; }
    }

    public class ViewProduk
    {
        [Key]
        public int? produk { get; set; }
        public int? jumlah { get; set; }
        public int? satuan { get; set; }
    }
    public class IsiShipment
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
        public string NamaPelabuhanBantuan { get; set; }
        public string Proses { get; set; }
        public int? WaitingUllage { get; set; }
        public int? WaitingCargo { get; set; }

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
        public int? UpdateAntrian { get; set; }
        public int? Nojetty { get; set; }
        public int? Idbantuan { get; set; }
        public string Prosesbantuan { get; set; }
        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public int JumlahProduk { get; set; }
    }
}
