using System;
using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Parthership.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IntegrationAPI.Connection.Interface;
using IntegrationClassLib.Parthership.Service;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Service;
using IntegrationClassLib.Tendering.Service.Interface;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderingController : ControllerBase
    {
        private readonly ITenderService tenderService;
        private readonly IPharmacyOfferService pharmacyOfferService;
        private readonly IHospitalHttpConnection hospitalHttpConnection;
        private readonly IPharmacyHTTPConnection pharmacyHttpConnection;

        public TenderingController(ITenderService tenderService, IPharmacyOfferService pharmacyOfferService,
            IHospitalHttpConnection hospitalHttpConnection, IPharmacyHTTPConnection pharmacyHttpConnection)
        {
            this.tenderService = tenderService;
            this.pharmacyOfferService = pharmacyOfferService;
            this.hospitalHttpConnection = hospitalHttpConnection;
            this.pharmacyHttpConnection = pharmacyHttpConnection;
        }

        [HttpGet]
        [Route("tenders")]
        public List<Tender> GetAll()
        {
            return tenderService.GetAll();
        }

        [HttpPost]
        [Route("tenders")]
        public IActionResult CreateTender(TenderDto tenderDto)
        {
            Tender tender = TenderMapper.TenderDtoToTender(tenderDto);
            if (tender == null)
            {
                return BadRequest("End date format is not good");
            }

            if (tender.EndDate <= tender.StartDate)
            {
                return BadRequest("End date must be after " + tender.StartDate);
            }

            if (tender.TenderMedications.Count == 0)
            {
                return BadRequest("Must add minimum one medication");
            }

            return Ok(tenderService.Create(tender));
        }

        [HttpPut]
        [Route("tenders")]
        public IActionResult CloseTender(long id)
        {
            if (tenderService.CloseTender(id) != null)
            {
                return Ok();
            };
            return BadRequest();
        }

        [HttpGet]
        [Route("offers")]
        public List<PharmacyOffer> GetAllPharmacyOffers()
        {
            return pharmacyOfferService.GetAllPharmacyOffers();
        }

        [HttpGet]
        [Route("offers/getAllByTenderId")]
        public List<PharmacyOffer> GetAllPharmacyOffersByTenderId(long id)
        {
            return pharmacyOfferService.GetAllPharmacyOffersByTenderId(id);
        }

        [HttpPut]
        [Route("offers")]
        public IActionResult AcceptOffer(long id)
        {
            try
            {
                PharmacyOffer pharmacyOffer = TryOfferClosing(id);

                foreach (PharmacyOfferComponent component in pharmacyOffer.Components)
                {
                    hospitalHttpConnection.SaveMedication(new MedicationDto()
                        { Name = component.MedicationName, Quantity = (int)component.Quantity });
                }

                return Ok(pharmacyOffer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private PharmacyOffer TryOfferClosing(long id)
        {
            PharmacyOffer pharmacyOffer = pharmacyOfferService.GetPharmacyOfferById(id);
            List<PharmacyOffer> pharmacyOffers =
                pharmacyOfferService.GetAllPharmacyOffersByTenderId(pharmacyOffer.TenderId);

            bool pharmacyHasMedicines = pharmacyHttpConnection.SendTenderOutcomeToWinnerPharmacy(pharmacyOffer);
            if (pharmacyHasMedicines)
            {
                pharmacyHttpConnection.SendTenderOutcomeToAllLoserPharmacies(pharmacyOffers, id);
                if (tenderService.AcceptOfferAndCloseTender(pharmacyOffer.TenderId, id) == null)
                {
                    throw new Exception("Closing tender error");
                }

                return pharmacyOffer;
            }

            throw new Exception("Accepting offer gone wrong");
        }
    }
}