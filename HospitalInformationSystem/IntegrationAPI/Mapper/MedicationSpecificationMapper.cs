using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class MedicationSpecificationMapper
    {
        public static MedicationSpecification MedicationSpecificationDTOToMedicationSpecification(MedicationSpecificationDTO medicationConsumptionDTO)
        {
            return new MedicationSpecification(medicationConsumptionDTO.PharmacyName, medicationConsumptionDTO.MedicationName);
        }
    }
}
