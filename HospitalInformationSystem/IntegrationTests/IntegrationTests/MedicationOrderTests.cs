using IntegrationAPI.Connection;
using IntegrationAPI.Controllers;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using Xunit;

namespace IntegrationTests
{
    public class MedicationOrderTests
    {
        [Fact]
        public void Primary_pharmacy_name_is_not_available()
        {
            MedicationController medicationController = GetMedicationController();

            IActionResult retVal = medicationController.OrderMedication(new IntegrationAPI.Dto.OrderMedicationDto() { PharmacyName = "alksdsaasd" });

            retVal.ShouldBeOfType<BadRequestResult>();
        }

        [Fact]
        public void Pharmacy_id_is_not_good()
        {
            MedicationController medicationController = GetMedicationController();

            IActionResult retVal = medicationController.OrderMedication(new IntegrationAPI.Dto.OrderMedicationDto() { PharmacyName = "Apoteka1", PharmacyId = -1 });

            retVal.ShouldBeOfType<BadRequestResult>();
        }

        [Fact]
        public void Medication_order_is_successfully()
        {
            MedicationController medicationController = GetMedicationController();

            IActionResult retVal = medicationController.OrderMedication(new IntegrationAPI.Dto.OrderMedicationDto() { PharmacyName = "Apoteka1", PharmacyId = 1, MedicationId = 1, Quantity = 0 });

            retVal.ShouldBeOfType<OkResult>();
        }

        private MedicationController GetMedicationController()
        {
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            MedicationController controller = new MedicationController(pharmacyService, new PharmacyHTTPConnection());
            return controller;
        }
    }
}
