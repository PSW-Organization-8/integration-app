using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Service.Interface;
using System;
using System.Collections.Generic;

namespace IntegrationClassLib.Pharmacy.Service
{
    public class PharmacyService
    {
        private readonly IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public Model.Pharmacy Add(Model.Pharmacy pharmacy)
        {
            return pharmacyRepository.Create(pharmacy);
        }

        public List<Model.Pharmacy> GetAll()
        {
            return pharmacyRepository.GetAll();
        }

        public Model.Pharmacy GetByApiKey(string key)
        {
            return pharmacyRepository.GetPharmacyByApiKey(key);
        }

        public Model.Pharmacy GetByName(string name) {
            return pharmacyRepository.GetPharmacyByName(name);
        }

        public bool ExistsByApiKey(string key) {
            return pharmacyRepository.ExistsByApiKey(key);
        }
    }
}
