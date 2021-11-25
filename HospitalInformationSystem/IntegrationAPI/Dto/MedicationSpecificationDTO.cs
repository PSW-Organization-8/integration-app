using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class MedicationSpecificationDTO
    {
        public string PharmacyName { get; set; }
        public string MedicationName { get; set; }

        public MedicationSpecificationDTO()
        {
        }

        public MedicationSpecificationDTO(string pharmacyName, string medicationName)
        {
            PharmacyName = pharmacyName;
            MedicationName = medicationName;
        }
    }
}
