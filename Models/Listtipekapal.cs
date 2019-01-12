using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Listtipekapal
    {
        public Listtipekapal()
        {
            Kapal = new HashSet<Kapal>();
        }

        public int Idlisttipekapal { get; set; }
        public string Namalisttipekapal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public ICollection<Kapal> Kapal { get; set; }
    }
}
