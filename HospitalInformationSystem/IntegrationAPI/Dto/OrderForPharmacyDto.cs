using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class OrderForPharmacyDto
    {
        public long PhamracyID { get; set; }
        public long MedicationID { get; set; }
        public long Quantity { get; set; }
    }
}
