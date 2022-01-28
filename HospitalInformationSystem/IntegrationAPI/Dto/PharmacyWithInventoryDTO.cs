using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dto
{
    public class PharmacyWithInventoryDTO
    {
        public PharmaciesWithAvailableMedicineDTO Pharmacy { get; set; }
        public List<AvailableMedicineDTO> Medications { get; set; }

        public PharmacyWithInventoryDTO() { }
        public PharmacyWithInventoryDTO(PharmaciesWithAvailableMedicineDTO pharmacy, List<AvailableMedicineDTO> medications)
        {
            this.Pharmacy = pharmacy;
            this.Medications = medications;
        }
    }
}
