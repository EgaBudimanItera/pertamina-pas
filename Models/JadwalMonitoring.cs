using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class JadwalMonitoring
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
    public class JadwalMonitoringCari
    {
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DariTanggal { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HinggaTanggal { get; set; }
        

        [Key]
        public int idpelabuhan { get; set; }
        public Pelabuhan pelabuhan { get; set; }
    }
    public class CetakMonitoring1
    {
        [Key]
        public string Idshipment { get; set; }
        public string Noshipment { get; set; }
        public string NamaKapal { get; set; }
        public string NamaAsalPelabuhan { get; set; }
        public string NamaTujuanPelabuhan { get; set; }
        public string Proses { get; set; }
        
        public string tgl { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? Arrival { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Berthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comm { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Unberthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }
        

        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }
      
        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public int JumlahProduk { get; set; }

    }
    public class CetakMonitoring2
    {
        [Key]
        public string Idshipment { get; set; }
        public string Noshipment { get; set; }
        public string NamaKapal { get; set; }
        public string NamaAsalPelabuhan { get; set; }
        public string NamaTujuanPelabuhan { get; set; }
        public string Proses { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? Arrival { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Berthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comm { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Unberthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }


        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }

        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public int JumlahProduk { get; set; }

    }
    public class CetakMonitoring3
    {
        [Key]
        public string Idshipment { get; set; }
        public string Noshipment { get; set; }
        public string NamaKapal { get; set; }
        public string NamaAsalPelabuhan { get; set; }
        public string NamaTujuanPelabuhan { get; set; }
        public string Proses { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? Arrival { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Berthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comm { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Unberthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }


        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }

        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public int JumlahProduk { get; set; }

    }
    public class CetakMonitoring4
    {
        [Key]
        public string Idshipment { get; set; }
        public string Noshipment { get; set; }
        public string NamaKapal { get; set; }
        public string NamaAsalPelabuhan { get; set; }
        public string NamaTujuanPelabuhan { get; set; }
        public string Proses { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? Arrival { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Berthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comm { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Comp { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Unberthed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }


        public string Status { get; set; }
        public int? Antrian { get; set; }
        public int? Nojetty { get; set; }

        public int Idpelabuhanbantuan { get; set; }
        public string Produk { get; set; }
        public int JumlahProduk { get; set; }

    }
    public class CetakMonitoring
    {
        public List<CetakMonitoring1> cetakMonitoring1s { get; set; }
        public List<CetakMonitoring2> cetakMonitoring2s { get; set; }
        public List<CetakMonitoring3> cetakMonitoring3s { get; set; }
        public List<CetakMonitoring4> cetakMonitoring4s { get; set; }
        [Key]
        [DisplayFormat(DataFormatString = "{0:dd-MM-YYYY}", ApplyFormatInEditMode = true)]
        public string tgl { get; set; }
    }
}
