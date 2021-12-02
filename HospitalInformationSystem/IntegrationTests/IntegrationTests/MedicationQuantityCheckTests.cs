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
        [Fact]
        public void Conection_with_pharmacy_formed()
        {
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            MedicationController contoller = new MedicationController(pharmacyService, new PharmacyHTTPConnection(), new PharmacyGrpcConnection(), new HospitalHttpConnection());

            List<PharmacyWithInventoryDTO> retVal = contoller.CheckMedicationQuantity("Ventolin", "25", "Apoteka1");

            retVal.ShouldNotBeNull();
        }


    }
}
