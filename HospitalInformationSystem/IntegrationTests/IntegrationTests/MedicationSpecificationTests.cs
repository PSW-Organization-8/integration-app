using IntegrationAPI.Controllers;
using IntegrationAPI.Dto;
using IntegrationClassLib;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class MedicationSpecificationTests
    {
        [Fact]
        public void Primary_pharmacy_name_is_not_available()
        {
            MedicationSpecificationController medicationSpecificationController = GetMedicationSpecificationController();

            NotificationDTO retVal =medicationSpecificationController.MakeReport(new IntegrationAPI.Dto.MedicationSpecificationDTO { PharmacyName = "asdasdsafsa" });

            retVal.FileName.ShouldBe("pharmacyNameNotExists");
        }

        [Fact]
        /*public void SuccessSaveMedicationSpecification()
        {
            MedicationSpecificationController medicationSpecificationController = GetMedicationSpecificationController();

            string retVal = medicationSpecificationController.MakeReport(new IntegrationAPI.Dto.MedicationSpecificationDTO { PharmacyName = "Apoteka1", MedicationName="Ventolin" });

            retVal.ShouldBe("\"OK\"");
        }*/


        private MedicationSpecificationController GetMedicationSpecificationController()
        {
            MyDbContext dbContext = new MyDbContext();
            IPharmacyRepository pharmacyRepository = new PharmacyRepository(dbContext);
            MedicationSpecificationService medicationSpecificationService = new MedicationSpecificationService();
            PharmacyService pharmacyService = new PharmacyService(pharmacyRepository);
            MedicationSpecificationController controller = new MedicationSpecificationController(medicationSpecificationService, pharmacyService);
            return controller;
        }
    }
}
