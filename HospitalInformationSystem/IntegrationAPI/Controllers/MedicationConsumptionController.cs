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
    public class MedicationConsumptionController : ControllerBase
    {
        private readonly MedicationConsumptionService medicationConsumptionService;

        public MedicationConsumptionController(MedicationConsumptionService medicationConsumptionService)
        {
            this.medicationConsumptionService = medicationConsumptionService;
           
        }

        [HttpGet]
        public List<MedicationConsumption> GetAll()
        {
            return medicationConsumptionService.GetAll();
        }

        [HttpPost]
        public IActionResult MakeReport(MedicationConsumptionDTO period)
        {
            if (medicationConsumptionService.CreateReport(MedicationConsumptionMapper.MedicationConsumptionDTOToMedicationConsumptionDuration(period)))
            {
                return Ok();
            }
            else {
                return StatusCode(500, "Error! Report not sent to pharmacy!");
            }
        }

    }
}
