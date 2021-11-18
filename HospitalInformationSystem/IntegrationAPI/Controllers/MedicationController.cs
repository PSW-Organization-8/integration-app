using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationClassLib.Pharmacy.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly PharmacyService pharmacyService;
        private readonly IMedicationService medicationService;
        public MedicationController(PharmacyService pharmacyService, IMedicationService medicationService)
        {
            this.pharmacyService = pharmacyService;
            this.medicationService = medicationService;
        }

        [HttpGet]
        [Route("check_medication_availability")]
        public List<PharmacyWithInventoryDTO> CheckMedicationQuantity([FromQuery(Name = "Name")] string Name, [FromQuery(Name = "Quantity")] string Quantity, [FromQuery(Name = "Pharmacy")] string Pharmacy)
        {
            Pharmacy pharmacy = pharmacyService.GetByName(Pharmacy);
            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/inventory");
            RestRequest request = new RestRequest();
            Parameter parameter = new Parameter("name", Name, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            parameter = new Parameter("quantity", Quantity, ParameterType.GetOrPost);
            request.AddParameter(parameter);
            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Get<List<PharmacyWithInventoryDTO>>(request);
            return data.Data;
        }

        [HttpPut]
        [Route("order_medication")]
        public IActionResult OrderMedication(OrderMedicationDto orderMedicationDto)
        {
            Pharmacy pharmacy = pharmacyService.GetByName(orderMedicationDto.PharmacyName);
            if (pharmacy == null)
            {
                return BadRequest();
            }

            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/inventory/remove_medication");
            RestRequest request = new RestRequest();

            var order = new OrderForPharmacyDto { PhamracyID = orderMedicationDto.PharmacyId, MedicationID = orderMedicationDto.MedicationId, Quantity = orderMedicationDto.Quantity };
            request.AddJsonBody(order);

            request.AddHeader("ApiKey", pharmacy.ApiKey);
            var data = restClient.Put<bool>(request);

            if(data.StatusCode != System.Net.HttpStatusCode.OK || data.Content.Equals("false"))
            {
                return BadRequest();
            }

            Medication newMedication = new Medication { Name = orderMedicationDto.MedicationName, Quantity = orderMedicationDto.Quantity };

            if(medicationService.AddMedicationFromPharmacy(newMedication) == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
