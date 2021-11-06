﻿using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
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

        public Model.Pharmacy GetByName(string name) {
            List<Model.Pharmacy> pharmacies = pharmacyRepository.GetAll();
            foreach (Model.Pharmacy pharmacy in pharmacies) {
                if (pharmacy.Name.Equals(name)) {
                    return pharmacy;
                }
            }
            return null;
        }
    }
}