using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
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
        public MedicationController(PharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
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



            MedicationDto newMedication = new MedicationDto { Name = orderMedicationDto.MedicationName, Quantity = orderMedicationDto.Quantity };

            RestClient restClientHospital = new RestClient("http://localhost:16934/api/Medcation/save_medication"); 
            RestRequest requestHospital = new RestRequest();

            requestHospital.AddJsonBody(newMedication);

            var dataHospital = restClientHospital.Post<IActionResult>(requestHospital);

            if (dataHospital.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
