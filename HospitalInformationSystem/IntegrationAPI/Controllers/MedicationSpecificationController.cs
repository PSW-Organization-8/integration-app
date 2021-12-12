using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
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
    public class MedicationSpecificationController : ControllerBase
    {

        private readonly MedicationSpecificationService medicationSpecificationService;
        private readonly PharmacyService pharmacyService;

        public MedicationSpecificationController(MedicationSpecificationService medicationSpecificationService, PharmacyService pharmacyService)
        {
            this.medicationSpecificationService = medicationSpecificationService;
            this.pharmacyService = pharmacyService;
        }
        [HttpPost]
        public NotificationDTO MakeReport(MedicationSpecificationDTO medicationSpecificationDTO)
        {
            Pharmacy pharmacy = pharmacyService.GetByName(medicationSpecificationDTO.PharmacyName);
            if (pharmacy == null)
            {
                NotificationDTO notification = new NotificationDTO("pharmacyNameNotExists");
                return notification;
            }

            RestClient restClient = new RestClient(pharmacy.Url + ":" + pharmacy.Port + "/api/medicationSpecification");
            RestRequest request = new RestRequest();
            request.AddJsonBody(medicationSpecificationDTO.MedicationName);

            var response = restClient.Post(request);
            if (response.Content.ToString().Equals("\"OK\""))
            {
                NotificationDTO notification= new NotificationDTO (medicationSpecificationService.GetSpecificationnReport(medicationSpecificationDTO.MedicationName));
                return notification;
            }
            NotificationDTO notificationDTO = new NotificationDTO("");
            return notificationDTO;
            
        }
    }
}
