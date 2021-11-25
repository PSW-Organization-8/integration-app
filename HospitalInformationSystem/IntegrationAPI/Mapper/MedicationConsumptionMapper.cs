using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class MedicationConsumptionMapper
    {
        public static MedicationConsumptionDuration MedicationConsumptionDTOToMedicationConsumptionDuration(MedicationConsumptionDTO medicationConsumptionDTO)
        {
            return new MedicationConsumptionDuration(medicationConsumptionDTO.DurationStart, medicationConsumptionDTO.DurationEnd);
        }
    }
}
