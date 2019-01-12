using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Listsatuan
    {
        public Listsatuan()
        {
            KapalSatuanflowrateNavigation = new HashSet<Kapal>();
            KapalSatuankapasitasNavigation = new HashSet<Kapal>();
        }

        public int IdListsatuan { get; set; }
        public string NamaSatuan { get; set; }
        public string SimbolSatuan { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public ICollection<Kapal> KapalSatuanflowrateNavigation { get; set; }
        public ICollection<Kapal> KapalSatuankapasitasNavigation { get; set; }
    }
}
