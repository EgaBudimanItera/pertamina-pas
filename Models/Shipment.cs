using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            Detailshipment = new HashSet<Detailshipment>();
        }

        public int Idshipment { get; set; }
        public string Noshipment { get; set; }
        public int? Idkapal { get; set; }
        public int? Idasal { get; set; }
        public int? Idtujuan { get; set; }
        public string Proses { get; set; }
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
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public Pelabuhan IdasalNavigation { get; set; }
        public Kapal IdkapalNavigation { get; set; }
        public Pelabuhan IdpelabuhanbantuanNavigation { get; set; }
        public Pelabuhan IdtujuanNavigation { get; set; }
        public ICollection<Detailshipment> Detailshipment { get; set; }
    }
}
