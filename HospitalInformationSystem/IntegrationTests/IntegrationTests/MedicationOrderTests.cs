using IntegrationAPI.Connection;
using IntegrationAPI.Controllers;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using System;
using System.Collections.Generic;
using IntegrationTests.InMemoryRepository;
using Xunit;

namespace IntegrationTests
{
    public class MedicationOrderTests
    {
        [Theory]
        [MemberData(nameof(MedicationOrderTestData))]
        public void Ordering_medication(string PharmacyName, int PharmacyId, int MedicationId, int Quantity, StatusCodeResult ResultType)
        {
            MedicationController medicationController = GetMedicationController();

            IActionResult retVal = medicationController.OrderMedication(new IntegrationAPI.Dto.OrderMedicationDto() { PharmacyName = PharmacyName, PharmacyId = PharmacyId, MedicationId = MedicationId, Quantity = Quantity });

            retVal.ShouldBeOfType(ResultType.GetType());
        }

        private MedicationController GetMedicationController()
        {
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            MedicationController controller = new MedicationController(pharmacyService, new PharmacyHTTPConnection(new PharmacyService(new PharmacyTestRepository())), new PharmacyGrpcConnection(), new HospitalHttpConnection());
            return controller;
        }

        public static IEnumerable<object[]> MedicationOrderTestData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "asdasdasfas", 0, 0, 0, new BadRequestResult() });
            retVal.Add(new object[] { "Apoteka1", -1, 0, 0, new BadRequestResult() });
            //retVal.Add(new object[] { "Apoteka1", 1, 1, 0, new OkResult() });
            //retVal.Add(new object[] { "Apoteka2", 1, 1, 0, new OkResult() });

            return retVal;
        }
    }
}
