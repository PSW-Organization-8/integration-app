using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IntegrationAPI.Controllers;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service;
using IntegrationTests.InMemoryRepository;
using Shouldly;
using Xunit;

namespace IntegrationTests.UnitTests
{
    public class PharmacyTests
    {
        private IPharmacyRepository pharmacyRepository = new PharmacyTestRepository();
        private PharmacyService pharmacyService;

        public PharmacyTests()
        {
            pharmacyService = new PharmacyService(pharmacyRepository);
        }

        [Fact]
        public void Pharmacy_update_test()
        {
            Pharmacy updatedPharmacy1 = pharmacyRepository.Get(1);
            Pharmacy updatedPharmacy2 = pharmacyRepository.Get(3);
            updatedPharmacy1.ApiKey = "noviApiKey";
            updatedPharmacy2.Notes = "dodat novi notes";

            Pharmacy test1 = pharmacyService.Update(updatedPharmacy1);
            Pharmacy test2 = pharmacyService.Update(updatedPharmacy2);

            
            IsPharmaciesEquals(updatedPharmacy1, test1).ShouldBeTrue();
            IsPharmaciesEquals(updatedPharmacy2, test2).ShouldBeTrue();
            IsPharmaciesEquals(updatedPharmacy1, test2).ShouldBeFalse();
        }

        private bool IsPharmaciesEquals(Pharmacy firstPharmacy, Pharmacy secondPharmacy)
        {
            return firstPharmacy.Id.Equals(secondPharmacy.Id) && firstPharmacy.ApiKey.Equals(secondPharmacy.ApiKey) &&
                    firstPharmacy.Name.Equals(secondPharmacy.Name) && firstPharmacy.Url.Equals(secondPharmacy.Url) &&
                    firstPharmacy.Port.Equals(secondPharmacy.Port) && firstPharmacy.Notes.Equals(secondPharmacy.Notes);
        }
    }
}
