using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Estimasiwaktu
    {
        public int Idestimasiwaktu { get; set; }
        public int? Idkapal { get; set; }
        public int? Idlistpelabuhan { get; set; }
        public int? Idlistket { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }
        public string Estimasiwaktu1 { get; set; }

        public Kapal IdkapalNavigation { get; set; }
        public Listketerangan IdlistketNavigation { get; set; }
        public Pelabuhan IdlistpelabuhanNavigation { get; set; }
    }
}
