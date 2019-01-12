using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class TbChat
    {
        public int Idchat { get; set; }
        public string Iduser { get; set; }
        public string Tanggalchat { get; set; }
        public string Isichat { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }
    }
}
