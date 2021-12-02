using IntegrationAPI.Dto;
using IntegrationAPI.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Mapper
{
    public class MedicationMapper
    {
        public static List<PharmacyWithInventoryDTO> PharmacyDtoToPharmacy(CheckMedicationAvailabilityResponseProto response)
        {
            List<PharmacyWithInventoryDTO> retVal = new List<PharmacyWithInventoryDTO>();

            foreach (var item in response.MedicationAvailability)
            {
                PharmacyWithInventoryDTO pharmacyWithInventoryDTO = new PharmacyWithInventoryDTO();
                pharmacyWithInventoryDTO.Pharmacy = new PharmaciesWithAvailableMedicineDTO() { Id = item.Pharmacy.Id, Name = item.Pharmacy.Name, Adress = item.Pharmacy.Adress, AdressNumber = item.Pharmacy.AdressNumber, City = item.Pharmacy.City };
                pharmacyWithInventoryDTO.Medications = AddMedication(item);
                retVal.Add(pharmacyWithInventoryDTO);

            }
            return retVal;
        }

        private static List<AvailableMedicineDTO> AddMedication(MedicationAvailabilityProto item)
        {
            List<AvailableMedicineDTO> medications = new List<AvailableMedicineDTO>();
            foreach (var medication in item.Medications)
            {
                AvailableMedicineDTO medicine = new AvailableMedicineDTO() { Name = medication.Name, Id = medication.Id };
                medications.Add(medicine);

            }
            return medications;
        }
    }
}
