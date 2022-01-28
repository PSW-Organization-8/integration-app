using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Spire.Pdf.OPC;
using System.IO;
using System.Drawing;
using System;
using IntegrationClassLib.Parthership.Service;
using IntegrationClassLib.Parthership.Service.Interface;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly PharmacyService pharmacyService;

        public PharmacyController(PharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        [HttpGet]
        public List<Pharmacy> GetAll()
        {
            return pharmacyService.GetAll();
        }

        [HttpGet]
        [Route("pharmacyProfile")]
        public Pharmacy GetPharmacyById(long id)
        {
            return pharmacyService.GetById(id);
        }

        [HttpPost]
        public Pharmacy Add(PharmacyDto pharmacyDto)
        {
            return pharmacyService.Add(PharmacyMapper.PharmacyDtoToPharmacy(pharmacyDto));
        }

        [HttpPut]
        [Route("updatePharmacy")]
        public IActionResult UpdatePharmacy(PharmacyDto pharmacyDto)
        {
            if (pharmacyDto == null) return BadRequest();
            Pharmacy pharmacy = pharmacyService.GetByName(pharmacyDto.Name);
            if (pharmacy == null) return BadRequest();


            Pharmacy updatedPharmacy = pharmacyService.Update(PharmacyMapper.PharmacyDtoToPharmacy(pharmacyDto));
            return Ok(updatedPharmacy);
        }

        [HttpPost]
        [Route("uploadPharmacyImage")]
        public IActionResult UploadPharmacyImage([FromForm] IFormFile image, long id = 0)
        {
            if (id <= 0 || image == null || image.Length == 0) return BadRequest();

            string base64Image;
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                var fileBytes = memoryStream.ToArray();
                base64Image = Convert.ToBase64String(fileBytes);
            }

            Pharmacy updatedPharmacy = pharmacyService.SavePharmacyImage(base64Image, id);
            return Ok(updatedPharmacy);
        }
    }
}
