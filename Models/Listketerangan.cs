using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Listketerangan
    {
        public Listketerangan()
        {
            Estimasiwaktu = new HashSet<Estimasiwaktu>();
        }

        public int Idlistketerangan { get; set; }
        public string Namaketerangan { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public ICollection<Estimasiwaktu> Estimasiwaktu { get; set; }
    }
}
