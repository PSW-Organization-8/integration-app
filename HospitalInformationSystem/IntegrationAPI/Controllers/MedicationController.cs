using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly PharmacyService pharmacyService;
        public MedicationController(PharmacyService pharmacyService) {
            this.pharmacyService = pharmacyService;
        }

        [HttpPost]
        public List<PharmacyWithInventoryDTO> CheckMedicationQuantity(MedicationQuantityDTO medicationQuantiti) 
        {
            Pharmacy pharmacy = pharmacyService.GetByName(medicationQuantiti.Pharmacy);
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/inventory");
            RestRequest request = new RestRequest();
            Parameter parameter = new Parameter("name", medicationQuantiti.Name, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            parameter = new Parameter("quantity", medicationQuantiti.Quantity, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Get<List<PharmacyWithInventoryDTO>>(request);
            return data.Data;
        }
    }
}
