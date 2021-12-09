using IntegrationAPI.Connection;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dto;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace IntegrationTests
{
    public class MedicationQuantityCheckTests
    {
        [Theory]
        [MemberData(nameof(MedicationQuantityTestData))]
        public void Conection_with_pharmacy_formed(string medication, string quantity, string pharmacyName)
        {
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            MedicationController contoller = new MedicationController(pharmacyService, new PharmacyHTTPConnection(), new PharmacyGrpcConnection(), new HospitalHttpConnection());

            List<PharmacyWithInventoryDTO> retVal = contoller.CheckMedicationQuantity(medication, quantity, pharmacyName);

            retVal.ShouldNotBeNull();
        }

        public static IEnumerable<object[]> MedicationQuantityTestData()
        {
            var retVal = new List<object[]>();

            //retVal.Add(new object[] { "Ventolin", "25", "Apoteka1" });
            //retVal.Add(new object[] { "Ventolin", "25", "Apoteka2" });

            return retVal;
        }


    }
}
