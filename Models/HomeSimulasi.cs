using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class HomeSimulasi
    {
        public List<PortSchedule> PortSchedules { get; set; }
        public List<PortActivityJetty1> portActivityJetty1s { get; set; }
        public List<PortActivityJetty2> portActivityJetty2s { get; set; }
    }
}
