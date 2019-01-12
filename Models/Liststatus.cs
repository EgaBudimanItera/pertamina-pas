using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Liststatus
    {
        public int Idstatus { get; set; }
        public string Namastatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }
    }
}
