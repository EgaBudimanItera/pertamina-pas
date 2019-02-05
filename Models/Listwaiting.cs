using System;
using System.Collections.Generic;

namespace pas_pertamina.Models
{
    public partial class Listwaiting
    {
        public int Idlistwaiting { get; set; }
        public string Namalistwaiting { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string SoftDelete { get; set; }

        public PortActivityJetty1 idwaitingnavigation1 { get; set; }
        public PortActivityJetty1 idwaitingnavigation2 { get; set; }
        public PortActivityJetty1 idwaitingnavigation3 { get; set; }
        public PortActivityJetty1 idwaitingnavigation4 { get; set; }
        public PortActivityJetty1 idwaitingnavigation5 { get; set; }
    }
}
