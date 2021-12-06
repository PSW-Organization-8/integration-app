using IntegrationAPI.Dto;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Pharmacy.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection.Interface
{
    public interface IPharmacyHTTPConnection
    {
        bool MedicationQuantityExists(string name, int quantity, Pharmacy pharmacy);

        IActionResult DownloadReceiptToPharmacy(Pharmacy pharmacy, string patientName);

        void SendObjectionToPharmacy(Pharmacy pharmacy, Objection newObjection);

        List<PharmacyWithInventoryDTO> GetPharmaciesWithAvailableMedicine(Pharmacy pharmacy, string name, string quantity);
    }
}
