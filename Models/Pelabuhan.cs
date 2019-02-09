using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Pelabuhan
    {
        public Pelabuhan()
        {
            Estimasiwaktu = new HashSet<Estimasiwaktu>();
            RuteIdasalNavigation = new HashSet<Rute>();
            RuteIdtujuanNavigation = new HashSet<Rute>();
            ShipmentIdasalNavigation = new HashSet<Shipment>();
            ShipmentIdpelabuhanbantuanNavigation = new HashSet<Shipment>();
            ShipmentIdtujuanNavigation = new HashSet<Shipment>();
            Stok = new HashSet<Stok>();
            Userlogin = new HashSet<Userlogin>();
        }

        public int Idlistpelabuhan { get; set; }
        public string Kodepelabuhan { get; set; }
        public string Namapelabuhan { get; set; }
        public string Jenisproduk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }
        public string Baseline { get; set; }

        public ICollection<Estimasiwaktu> Estimasiwaktu { get; set; }
        public ICollection<Rute> RuteIdasalNavigation { get; set; }
        public ICollection<Rute> RuteIdtujuanNavigation { get; set; }
        public ICollection<JadwalMonitoringCari> jadwalMonitoringCaris { get; set; }
        public ICollection<Shipment> ShipmentIdasalNavigation { get; set; }
        public ICollection<Shipment> ShipmentIdpelabuhanbantuanNavigation { get; set; }
        public ICollection<Shipment> ShipmentIdtujuanNavigation { get; set; }
        public ICollection<Stok> Stok { get; set; }
        public ICollection<Userlogin> Userlogin { get; set; }
    }
}
