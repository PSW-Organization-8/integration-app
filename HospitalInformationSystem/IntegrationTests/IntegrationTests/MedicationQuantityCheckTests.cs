using IntegrationAPI.Connection;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dto;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntegrationTests
{
    public class MedicationQuantityCheckTests
    {

        string localTest = Environment.GetEnvironmentVariable("LOCAL_TEST") ?? "false";

        [SkippableTheory]
        [MemberData(nameof(MedicationQuantityTestData))]
        public void Conection_with_pharmacy_formed(string medication, string quantity, string pharmacyName)
        {
            Skip.IfNot(localTest.Equals("true"));
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            MedicationController contoller = new MedicationController(pharmacyService, new PharmacyHTTPConnection(pharmacyService), new PharmacyGrpcConnection(), new HospitalHttpConnection());

            List<PharmacyWithInventoryDTO> retVal = contoller.CheckMedicationQuantity(medication, quantity, pharmacyName);

            retVal.ShouldNotBeNull();
        }

        public static IEnumerable<object[]> MedicationQuantityTestData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Ventolin", "25", "Apoteka1" });
            retVal.Add(new object[] { "Ventolin", "25", "Apoteka2" });

            return retVal;
        }
    }
}
