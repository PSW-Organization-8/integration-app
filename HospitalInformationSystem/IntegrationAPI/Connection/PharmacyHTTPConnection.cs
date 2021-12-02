using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Dto;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Pharmacy.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationAPI.Connection
{
    public class PharmacyHTTPConnection : IPharmacyHTTPConnection
    {
        public IActionResult DownloadReceiptToPharmacy(Pharmacy pharmacy, string patientName)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/receipt");
            RestRequest request = new RestRequest();
            Parameter parameter = new Parameter("patientName", patientName, ParameterType.GetOrPost);
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

        public void SendObjectionToPharmacy(Pharmacy pharmacy, Objection newObjection)
        {
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/Objection");
            RestRequest request = new RestRequest();
            request.AddJsonBody(newObjection);
            request.AddHeader("ApiKey", pharmacy.ApiKey);
            restClient.Post(request);
        }
    }
}
