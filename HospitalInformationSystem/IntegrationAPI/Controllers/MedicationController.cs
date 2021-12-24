using IntegrationAPI.Connection.Interface;
using IntegrationAPI.Dto;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly PharmacyService pharmacyService;
        private readonly IPharmacyHTTPConnection hTTPConnection;
        private readonly IPharmacyGrpcConnection grpcConnection;
        private readonly IHospitalHttpConnection hospitalHttpConnection;

        public MedicationController(PharmacyService pharmacyService, IPharmacyHTTPConnection hTTPConnection, IPharmacyGrpcConnection grpcConnection, IHospitalHttpConnection hospitalHttpConnection)
        {
            this.pharmacyService = pharmacyService;
            this.hTTPConnection = hTTPConnection;
            this.grpcConnection = grpcConnection;
            this.hospitalHttpConnection = hospitalHttpConnection;
        }

        [HttpGet]
        [Route("check_medication_availability")]
        public List<PharmacyWithInventoryDTO> CheckMedicationQuantity([FromQuery(Name = "Name")] string Name, [FromQuery(Name = "Quantity")] string Quantity, [FromQuery(Name = "Pharmacy")] string Pharmacy)
        {
            Pharmacy pharmacy = pharmacyService.GetByName(Pharmacy);
            if (pharmacy.ComunicateWithGrpc)
            {
                return grpcConnection.GetPharmaciesWithAvailableMedicine(pharmacy, Name, Quantity);
            }
            else
            {
                return hTTPConnection.GetPharmaciesWithAvailableMedicine(pharmacy, Name, Quantity);
            }
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

            MedicationDto medicationDto = new MedicationDto { Name = orderMedicationDto.MedicationName, Quantity = orderMedicationDto.Quantity };

            if (pharmacy.ComunicateWithGrpc)
            {
                if (grpcConnection.OrderMedication(pharmacy, orderMedicationDto))
                {
                    if (hospitalHttpConnection.SaveMedication(medicationDto))
                    {
                        return Ok();
                    }
                    else
                    {
                        hTTPConnection.ReturnMedication(pharmacy, orderMedicationDto);
                    }
                }

            }
            else
            {
                if (hTTPConnection.OrderMedication(pharmacy, orderMedicationDto))
                {
                    if (hospitalHttpConnection.SaveMedication(medicationDto))
                    {
                        return Ok();
                    }
                    else
                    {
                        hTTPConnection.ReturnMedication(pharmacy, orderMedicationDto);
                    }
                }
            }

            return BadRequest();
        }
    }
}
