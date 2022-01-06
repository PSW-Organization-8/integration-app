using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI.Connection;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dto;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationClassLib.Tendering.Repository;
using IntegrationClassLib.Tendering.Service;
using IntegrationClassLib.Tendering.Service.Interface;
using IntegrationTests.InMemoryRepository;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using Xunit;

namespace IntegrationTests.IntegrationTests
{
    public class TenderingTests
    {
        private ITenderingRepository tenderingRepository;

        [Theory]
        [MemberData(nameof(CreatingTenderTestData))]
        public void creating_tenders(string tenderName, string complationDate, List<TenderMedicationDto> medicationDtos,
            ObjectResult objectResult, int tenderNum)
        {
            TenderingController tenderingController = GetTenderingController();

            IActionResult retVal = tenderingController.CreateTender(new TenderDto()
                { tenderName = tenderName, complationDate = complationDate, medications = medicationDtos });

            retVal.ShouldBeOfType(objectResult.GetType());
            tenderingController.GetAll().Count.ShouldBe(tenderNum);
        }

        [Theory]
        [MemberData(nameof(ClosingTenderTestData))]
        public void closing_tenders(long id, StatusCodeResult objectResult)
        {
            TenderingController tenderingController = GetTenderingController();

            IActionResult retVal = tenderingController.CloseTender(id);

            retVal.ShouldBeOfType(objectResult.GetType());
        }

        [Fact]
        public void tenders_number()
        {
            TenderingController tenderingController = GetTenderingController();

            var retVal = tenderingController.GetAll();

            retVal.Count.ShouldBe(1);
        }

        private TenderingController GetTenderingController()
        {
            MyDbContext dbContext = new MyDbContext();
            tenderingRepository = new TenderingTestRepository();
            TenderCommunicationRabbitMQService tenderCommunicationRabbitMqService =
                new TenderCommunicationRabbitMQService();
            ITenderService tenderService = new TenderService(tenderingRepository, tenderCommunicationRabbitMqService);
            IPharmacyOfferRepository offerRepository = new PharmacyOfferRepository(dbContext);
            IPharmacyOfferService pharmacyOfferService =
                new PharmacyOfferService(offerRepository, tenderService, tenderCommunicationRabbitMqService);
            TenderingController controller =
                new TenderingController(tenderService, pharmacyOfferService, new HospitalHttpConnection(), new PharmacyHTTPConnection(new PharmacyService(new PharmacyTestRepository())));
            return controller;
        }

        public static IEnumerable<object[]> CreatingTenderTestData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[]
                { "tenderTest1", "badDate", null, new BadRequestObjectResult(""), 1 });
            retVal.Add(new object[]
                { "tenderTest2", "2020-08-08", null, new BadRequestObjectResult(""), 1 });
            retVal.Add(new object[]
                { "tenderTest2", "2022-08-08", null, new BadRequestObjectResult(""), 1 });
            /*retVal.Add(new object[]
            {
                "tenderTest2", "2022-08-08",
                new List<TenderMedicationDto> { new() { quantity = 1, medicationName = "asd" } },
                new OkObjectResult(""), 2
            });*/

            return retVal;
        }

        public static IEnumerable<object[]> ClosingTenderTestData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { -1, new BadRequestResult() });
            retVal.Add(new object[] { 1, new OkResult() });
            return retVal;
        }
    }
}