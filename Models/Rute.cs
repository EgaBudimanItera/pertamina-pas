using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Rute
    {
        public int Idrute { get; set; }
        public int? Idkapal { get; set; }
        public int? Idasal { get; set; }
        public int? Idtujuan { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }
        public string Seatime { get; set; }

        public Pelabuhan IdasalNavigation { get; set; }
        public Kapal IdkapalNavigation { get; set; }
        public Pelabuhan IdtujuanNavigation { get; set; }
    }
}
