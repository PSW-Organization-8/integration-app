using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Parthership.Model.Tendering;
using IntegrationClassLib.Parthership.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderingController : ControllerBase
    {
        private readonly ITenderService tenderService;

        public TenderingController(ITenderService tenderService)
        {
            this.tenderService = tenderService;
        }

        [HttpGet]
        public List<Tender> GetAll()
        {
            return tenderService.GetAll();
        }

        [HttpPost]
        public IActionResult CreateTender(TenderDto tenderDto)
        {
            Tender tender = TenderMapper.TenderDtoToTender(tenderDto);
            if(tender == null)
            {
                return BadRequest("End date format is not good");
            }
            if(tender.EndDate <= tender.StartDate)
            {
                return BadRequest("End date must be after " + tender.StartDate);
            }
            if(tender.TenderMedications.Count == 0)
            {
                return BadRequest("Must add minimum one medication");
            }

            return Ok(tenderService.Create(tender));
        }

        [HttpPut]
        public IActionResult CloseTender(long id)
        {
            return Ok(tenderService.CloseTender(id));
        }
    }
}
