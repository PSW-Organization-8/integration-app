using IntegrationAPI.Dto;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Pharmacy.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationClassLib.Tendering.Model;

namespace IntegrationAPI.Connection.Interface
{
    public interface IPharmacyHTTPConnection
    {
        bool MedicationQuantityExists(string name, int quantity, Pharmacy pharmacy);

        IActionResult DownloadReceiptToPharmacy(Pharmacy pharmacy, ReceiptDto receipt);

        bool SendQRCodeToPharmacy(Pharmacy pharmacy, ReceiptDto receipt, string path);

        void SendObjectionToPharmacy(Pharmacy pharmacy, Objection newObjection);

        List<PharmacyWithInventoryDTO> GetPharmaciesWithAvailableMedicine(Pharmacy pharmacy, string name, string quantity);

        bool OrderMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto);
        bool ReturnMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto);

        bool SendTenderOutcomeToWinnerPharmacy(PharmacyOffer pharmacyOffer);

        void SendTenderOutcomeToAllLoserPharmacies(List<PharmacyOffer> pharmacyOffers, long winnerOfferId);
    }
}
