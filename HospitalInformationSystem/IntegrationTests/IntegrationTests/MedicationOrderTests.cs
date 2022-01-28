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
        string localTest = Environment.GetEnvironmentVariable("LOCAL_TEST") ?? "false";

        [SkippableTheory]
        [MemberData(nameof(MedicationOrderTestData))]
        public void Ordering_medication(string PharmacyName, int PharmacyId, int MedicationId, int Quantity, int statusCode)
        {
            Skip.IfNot(localTest.Equals("true") || statusCode != 200);

            MedicationController medicationController = GetMedicationController();

            var retVal = medicationController.OrderMedication(new IntegrationAPI.Dto.OrderMedicationDto() { PharmacyName = PharmacyName, PharmacyId = PharmacyId, MedicationId = MedicationId, Quantity = Quantity });
            var result = retVal as ObjectResult;

            Assert.Equal(statusCode, result.StatusCode);
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

            retVal.Add(new object[] { "asdasdasfas", 0, 0, 0, 400 });
            retVal.Add(new object[] { "Apoteka1", -1, 0, 0, 500});
            retVal.Add(new object[] { "Apoteka1", 1, 1, 0, 200 });
            retVal.Add(new object[] { "Apoteka2", 1, 1, 0, 200 });

            return retVal;
        }
    }
}
