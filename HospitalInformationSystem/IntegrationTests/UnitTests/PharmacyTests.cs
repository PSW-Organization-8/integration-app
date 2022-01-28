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

            
            IsPharmaciesEqualsWithoutImage(updatedPharmacy1, test1).ShouldBeTrue();
            IsPharmaciesEqualsWithoutImage(updatedPharmacy2, test2).ShouldBeTrue();
            IsPharmaciesEqualsWithoutImage(updatedPharmacy1, test2).ShouldBeFalse();
        }

        [Fact]
        public void Pharmacy_picture_update()
        {
            Pharmacy pharmacy = pharmacyRepository.Get(1);

            Pharmacy testPharmacy = pharmacyService.SavePharmacyImage("data:image/png;base64,iVBORw0", 1);

            IsPharmaciesEqualsWithoutImage(pharmacy, testPharmacy).ShouldBeTrue();
            pharmacyRepository.Get(1).Base64Image.Equals("data:image/png;base64,iVBORw0").ShouldBeTrue();
        }

        [Fact]
        public void Pharmacy_image_dont_change_on_information_update()
        {
            Pharmacy pharmacy = pharmacyRepository.Get(1);
            pharmacy.ApiKey = "promenjen ApiKey sa frontenda";
            pharmacy.Base64Image = "prosledjene informacije za sliku koje ne bi trebale da uticu na pravu sliku u bazi";

            pharmacyService.SavePharmacyImage("data:image/png;base64,iVBORw0", 1);
            pharmacyService.Update(pharmacy);

            pharmacyRepository.Get(1).Base64Image.Equals("data:image/png;base64,iVBORw0").ShouldBeTrue();
        }

        private bool IsPharmaciesEqualsWithoutImage(Pharmacy firstPharmacy, Pharmacy secondPharmacy)
        {
            return firstPharmacy.Id.Equals(secondPharmacy.Id) && firstPharmacy.ApiKey.Equals(secondPharmacy.ApiKey) &&
                    firstPharmacy.Name.Equals(secondPharmacy.Name) && firstPharmacy.Url.Equals(secondPharmacy.Url) &&
                    firstPharmacy.Port.Equals(secondPharmacy.Port) && firstPharmacy.Notes.Equals(secondPharmacy.Notes);
        }
    }
}
