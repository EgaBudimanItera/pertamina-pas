using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Kapal
    {
        public Kapal()
        {
            Estimasiwaktu = new HashSet<Estimasiwaktu>();
            Rute = new HashSet<Rute>();
            Shipment = new HashSet<Shipment>();
        }

        public int Idkapal { get; set; }
        public string Namakapal { get; set; }
        public int? Idlisttipekapal { get; set; }
        public int? Kapasitas { get; set; }
        public int? Satuankapasitas { get; set; }
        public int? Flowrate { get; set; }
        public int? Satuanflowrate { get; set; }
        public string Jenisangkut { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public Listtipekapal IdlisttipekapalNavigation { get; set; }
        public Listsatuan SatuanflowrateNavigation { get; set; }
        public Listsatuan SatuankapasitasNavigation { get; set; }
        public ICollection<Estimasiwaktu> Estimasiwaktu { get; set; }
        public ICollection<Rute> Rute { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
