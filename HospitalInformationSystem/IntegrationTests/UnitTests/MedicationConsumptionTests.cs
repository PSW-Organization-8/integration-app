using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Repository.MedicationRepo;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationTests.InMemoryRepository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.UnitTests
{
    public class MedicationConsumptionTests
    {
        private IMedicationConsumptionRepository medicationConsumptionRepository;
        private MedicationConsumptionService medicationConsumptionService;

        [Fact]
        public void AllMedicationConsumptionInDuration()
        {
            PrepareServicesForReceivingTests();

            List<MedicationConsumption> allMedicationConsuption = medicationConsumptionService.AllMedicationConsumptionInDuration(new MedicationConsumptionDuration { DurationStart = new DateTime(2021, 11, 1, 0, 0, 0), DurationEnd = new DateTime(2021, 11, 6, 0, 0, 0) });

            allMedicationConsuption.Count.ShouldBe(3);
        }

        [Fact]
        public void NotAllMedicationConsumptionInDuration()
        {
            PrepareServicesForReceivingTests();

            List<MedicationConsumption> allMedicationConsuption = medicationConsumptionService.AllMedicationConsumptionInDuration(new MedicationConsumptionDuration { DurationStart = new DateTime(2021, 1, 1, 0, 0, 0), DurationEnd = new DateTime(2021, 1, 6, 0, 0, 0) });

            allMedicationConsuption.Count.ShouldBe(0);
        }

        [Fact]
        public void Message_receiving_AllMedicationConsumptionInDurationHas1Member()
        {
            PrepareServicesForReceivingTests();

            List<MedicationConsumption> allMedicationConsuption = medicationConsumptionService.AllMedicationConsumptionInDuration(new MedicationConsumptionDuration { DurationStart = new DateTime(2021, 11, 4, 0, 0, 0), DurationEnd = new DateTime(2021, 11, 6, 0, 0, 0) });

            allMedicationConsuption.Count.ShouldBe(1);
        }

        [Fact]
        public void TotalQuantityForOneMedicine()
        {
            PrepareServicesForReceivingTests();

            double allMedicationConsuption = medicationConsumptionService.TotalQuantityForOneMedication(medicationConsumptionRepository.Get(1), medicationConsumptionRepository.GetAll());

            allMedicationConsuption.ShouldBe(89644521);
        }

        private void PrepareServicesForReceivingTests()
        {
            medicationConsumptionRepository = new MedicationConsumptionTestRepository();
            medicationConsumptionService = new MedicationConsumptionService(medicationConsumptionRepository);
        }
    }
}
