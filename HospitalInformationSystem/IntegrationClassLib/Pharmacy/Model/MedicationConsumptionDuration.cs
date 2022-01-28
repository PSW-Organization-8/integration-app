using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Model
{
    public class MedicationConsumptionDuration
    {
        public DateTime DurationStart { get; set; }
        public DateTime DurationEnd { get; set; }
        public MedicationConsumptionDuration() { }
        
        public MedicationConsumptionDuration(DateTime durationStart, DateTime durationEnd)
        {

            DurationStart = durationStart;
            DurationEnd = durationEnd;
        }

    }
}
