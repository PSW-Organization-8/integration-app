using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;

namespace IntegrationTests.InMemoryRepository
{
    public class PharmacyTestRepository : IPharmacyRepository
    {
        private Dictionary<long, Pharmacy> allPharmacies = new Dictionary<long, Pharmacy>();

        public PharmacyTestRepository()
        {
            allPharmacies.Add(1, new Pharmacy(1, "Jankovic", "qqqwwweeerrr", "www.jankovic-apoteka.rs", "12345", "Sa njima je dobra saradnja"));
            allPharmacies.Add(3, new Pharmacy(3, "Benu", "jakoDugacakApiKey", "www.benu.rs", "552211", "Poruciti brufen 21.12.2021."));
        }

        public List<Pharmacy> GetAll()
        {
            return allPharmacies.Values.ToList();
        }

        public Pharmacy Get(long id)
        {
            return allPharmacies[id];
        }

        public Pharmacy Update(Pharmacy t)
        {
            allPharmacies[t.Id] = t;
            return allPharmacies[t.Id];
        }

        public Pharmacy Create(Pharmacy t)
        {
            allPharmacies.Add(t.Id, t);
            return allPharmacies[t.Id];
        }

        public bool ExistsById(long id)
        {
            return allPharmacies.ContainsKey(id);
        }

        public bool Delete(long id)
        {
            return allPharmacies.Remove(id);
        }

        public Pharmacy GetPharmacyByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByApiKey(string key)
        {
            throw new NotImplementedException();
        }

        public Pharmacy GetPharmacyByApiKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}
