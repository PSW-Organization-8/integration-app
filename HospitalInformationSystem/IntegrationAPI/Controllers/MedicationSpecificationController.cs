using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Mvc;
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
      
        private readonly MedicationSpecificationService medicationSpecificationService = new MedicationSpecificationService();
        private readonly PharmacyService pharmacyService;

        public MedicationSpecificationController(PharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }
        [HttpPost]
        public string MakeReport(MedicationSpecificationDTO medicationSpecificationDTO)
        {
            Pharmacy pharmacy = pharmacyService.GetByName(medicationSpecificationDTO.PharmacyName);
            return medicationSpecificationService.RequestReport(MedicationSpecificationMapper.MedicationSpecificationDTOToMedicationSpecification(medicationSpecificationDTO), pharmacy);


        }
    }
}
