using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class MedicationConsumptionDTO
    {
        public DateTime DurationStart { get; set; }
        public DateTime DurationEnd { get; set; }
        public MedicationConsumptionDTO() { }

        public MedicationConsumptionDTO( DateTime durationStart, DateTime durationEnd)
        {
            
            DurationStart = durationStart;
            DurationEnd = durationEnd;
        }
    }
}
