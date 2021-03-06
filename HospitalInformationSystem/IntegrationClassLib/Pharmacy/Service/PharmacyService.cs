using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using System;
using System.Collections.Generic;
using IntegrationClassLib.Parthership.Service.Interface;

namespace IntegrationClassLib.Pharmacy.Service
{
    public class PharmacyService
    {
        private readonly IPharmacyRepository pharmacyRepository;
        private readonly IChannelsForCommunication channelsForCommunication;

        public PharmacyService(IPharmacyRepository pharmacyRepository, IChannelsForCommunication channelsForCommunication = null)
        {
            this.pharmacyRepository = pharmacyRepository;
            this.channelsForCommunication = channelsForCommunication;
        }

        public Model.Pharmacy Add(Model.Pharmacy pharmacy)
        {
            if (channelsForCommunication != null) channelsForCommunication.CreateChannelsForPharmacy(pharmacy);
            return pharmacyRepository.Create(pharmacy);
        }

        public Model.Pharmacy Update(Model.Pharmacy pharmacy)
        {
            Model.Pharmacy pharmacyFromBase = pharmacyRepository.Get(pharmacy.Id);
            pharmacy.Base64Image = pharmacyFromBase.Base64Image;
            return pharmacyRepository.Update(pharmacy);
        }

        public Model.Pharmacy SavePharmacyImage(string base64Image, long id)
        {
            Model.Pharmacy pharmacy = pharmacyRepository.Get(id);
            if (pharmacy == null) return null;

            pharmacy.Base64Image = base64Image;

            return pharmacyRepository.Update(pharmacy);
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

        public Model.Pharmacy GetById(long id) {
            return pharmacyRepository.Get(id);
        }
    }
}
