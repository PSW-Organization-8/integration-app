using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Model;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Repository;

namespace IntegrationTests.InMemoryRepository
{
    public class TenderingTestRepository : ITenderingRepository
    {
        private Dictionary<long, Tender> allTender = new();

        public TenderingTestRepository()
        {
            allTender.Add(1, new Tender("tender1", new DateRange(DateTime.Now, null), new List<TenderMedication> { new TenderMedication() { Id = 1, TenderId = 1, Quantity = 1, MedicationName = "asd" } }) { Id = 1 });
        }

        public List<Tender> GetAll()
        {
            return allTender.Values.ToList();
        }

        public Tender Get(long id)
        {
            return allTender.ContainsKey(id) ? allTender[id] : null;
        }

        public Tender Update(Tender t)
        {
            allTender[t.Id] = t;
            return allTender[t.Id];
        }

        public Tender Create(Tender t)
        {
            allTender.Add(t.Id, t);
            return allTender[t.Id];
        }

        public bool ExistsById(long id)
        {
            return allTender.ContainsKey(id);
        }

        public bool Delete(long id)
        {
            return allTender.Remove(id);
        }

        public List<Tender> GetAllWithMedications()
        {
            return allTender.Values.ToList();
        }
    }
}
