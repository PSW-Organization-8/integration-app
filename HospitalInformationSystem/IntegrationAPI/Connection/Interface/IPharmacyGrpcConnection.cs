using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection.Interface
{
    public interface IPharmacyGrpcConnection
    {
        List<PharmacyWithInventoryDTO> GetPharmaciesWithAvailableMedicine(Pharmacy pharmacy, string name, string quantity);
        bool OrderMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto);
        bool ReturnMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto);
    }
}
