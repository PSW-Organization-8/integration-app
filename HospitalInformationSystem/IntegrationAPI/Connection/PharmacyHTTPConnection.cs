using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Dto;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Pharmacy.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationClassLib.Tendering.Model;

namespace IntegrationAPI.Connection
{
    public class PharmacyHTTPConnection : IPharmacyHTTPConnection
    {
        private readonly PharmacyService pharmacyService;
        public PharmacyHTTPConnection(PharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        public IActionResult DownloadReceiptToPharmacy(Pharmacy pharmacy, ReceiptDto receipt)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/receipt");
            RestRequest request = new RestRequest();
            string[] name = receipt.Patient.Split(" ");
            string id = Guid.NewGuid().ToString();
            string fileName = "Receipt" + name[0] + id + ".pdf";
            if (name.GetLength(0) == 2)
            {
                fileName = "Receipt" + name[0] + name[1] + id + ".pdf";
            }
            Parameter parameter = new Parameter("fileName", fileName, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            return restClient.Get<IActionResult>(request).Data;
        }

        public List<PharmacyWithInventoryDTO> GetPharmaciesWithAvailableMedicine(Pharmacy pharmacy, string name, string quantity)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/inventory");
            RestRequest request = new RestRequest();
            Parameter parameter = new Parameter("name", name, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            parameter = new Parameter("quantity", quantity, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Get<List<PharmacyWithInventoryDTO>>(request);
            return data.Data;
        }

        public bool MedicationQuantityExists(string name, int quantity, Pharmacy pharmacy)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/inventory/medication_exists");
            RestRequest request = new RestRequest();
            Parameter parameter = new Parameter("name", name, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            parameter = new Parameter("quantity", quantity, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Get<bool>(request);
            return JsonSerializer.Deserialize<bool>(data.Content);
        }

        public bool OrderMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/inventory/remove_medication");
            RestRequest request = new RestRequest();

            var order = new OrderForPharmacyDto { PhamracyID = orderMedicationDto.PharmacyId, MedicationID = orderMedicationDto.MedicationId, Quantity = orderMedicationDto.Quantity };
            request.AddJsonBody(order);

            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Put<bool>(request);

            if (data.StatusCode != System.Net.HttpStatusCode.OK || data.Content.Equals("false"))
            {
                return false;
            }
            return true;
        }

        public bool ReturnMedication(Pharmacy pharmacy, OrderMedicationDto orderMedicationDto)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/inventory/append_medication");
            RestRequest request = new RestRequest();

            var order = new OrderForPharmacyDto { PhamracyID = orderMedicationDto.PharmacyId, MedicationID = orderMedicationDto.MedicationId, Quantity = orderMedicationDto.Quantity };
            request.AddJsonBody(order);

            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Put<bool>(request);

            if (data.StatusCode != System.Net.HttpStatusCode.OK || data.Content.Equals("false"))
            {
                return false;
            }
            return true;
        }

        public bool SendObjectionToPharmacy(Pharmacy pharmacy, Objection newObjection)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/Objection");
            RestRequest request = new RestRequest();
            request.AddJsonBody(newObjection);
            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Post(request);
            if (data.StatusCode != System.Net.HttpStatusCode.OK) {
                return false;
            }
            return true;
        }

        public bool SendQRCodeToPharmacy(Pharmacy pharmacy, ReceiptDto receipt, string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            string file = Convert.ToBase64String(bytes);
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/receipt");
            RestRequest request = new RestRequest();
            string[] name = receipt.Patient.Split(" ");
            string id = Guid.NewGuid().ToString();
            string fileName = "Receipt" + name[0] + id + ".pdf";
            if (name.GetLength(0) == 2)
            {
                fileName = "Receipt" + name[0] + name[1] + id + ".pdf";
            }
            request.AddHeader("fileName", fileName);
            request.AddJsonBody(file);
            
            var data =  restClient.Post(request);
            if (data.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            return true;
        }

        public bool SendTenderOutcomeToWinnerPharmacy(PharmacyOffer pharmacyOffer)
        {
            Pharmacy winnerPharmacy = pharmacyService.GetByName(pharmacyOffer.PharmacyName);

            RestClient restClient = new RestClient(winnerPharmacy.Url + ":" + winnerPharmacy.Port + "/api/tender/receiveTenderOutcome");
            RestRequest request = new RestRequest();
            request.AddHeader("ApiKey", winnerPharmacy.ApiKey);
            TenderOutcomeDTO tenderOutcomeDto = new TenderOutcomeDTO(pharmacyOffer.OfferIdInPharmacy, true);
            request.AddJsonBody(tenderOutcomeDto);

            var data = restClient.Post(request);

            if (data.StatusCode != System.Net.HttpStatusCode.OK || data.Content.Equals("false"))
            {
                return false;
            }

            return true;
        }

        public void SendTenderOutcomeToAllLoserPharmacies(List<PharmacyOffer> pharmacyOffers, long winnerOfferId)
        {
            foreach (PharmacyOffer offer in pharmacyOffers)
            {
                // sending to all pharmacies that did not win
                if (!offer.Id.Equals(winnerOfferId))
                {
                    Pharmacy pharmacy = pharmacyService.GetByName(offer.PharmacyName);
                    SendTenderOutcomeToLoserPharmacy(pharmacy, offer);
                }
            }
        }

        private void SendTenderOutcomeToLoserPharmacy(Pharmacy pharmacy, PharmacyOffer pharmacyOffer)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/tender/receiveTenderOutcome");
            RestRequest request = new RestRequest();
            request.AddHeader("ApiKey", pharmacy.ApiKey);
            TenderOutcomeDTO tenderOutcomeDto = new TenderOutcomeDTO(pharmacyOffer.OfferIdInPharmacy, false);
            request.AddJsonBody(tenderOutcomeDto);

            restClient.Post(request);
        }
    }
}
