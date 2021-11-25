using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.Pharmacy.Repository.MedicationRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.InMemoryRepository
{
    public class MedicationConsumptionTestRepository : IMedicationConsumptionRepository
    {
        private Dictionary<long, MedicationConsumption> allMedicationConsumptions = new Dictionary<long, MedicationConsumption>();

        public MedicationConsumptionTestRepository()
        {
            allMedicationConsumptions.Add(1, new MedicationConsumption { MedicineID = 1, MedicineName = "medicine1", DateTime = new DateTime(2021, 11, 3, 1, 1, 1), Quantity = 89644521 });
            allMedicationConsumptions.Add(2, new MedicationConsumption { MedicineID = 2, MedicineName = "medicine2", DateTime = new DateTime(2021, 11, 5, 1, 1, 1), Quantity = 254 });
            allMedicationConsumptions.Add(3, new MedicationConsumption { MedicineID = 3, MedicineName = "medicine3", DateTime = new DateTime(2021, 11, 2, 1, 1, 1), Quantity = 147 });
        }

        public List<MedicationConsumption> GetAll()
        {
            return allMedicationConsumptions.Values.ToList();
        }

        public MedicationConsumption Get(long id)
        {
            return allMedicationConsumptions[id];
        }

        public MedicationConsumption Update(MedicationConsumption t)
        {
            allMedicationConsumptions[t.MedicineID] = t;
            return allMedicationConsumptions[t.MedicineID];
        }

        public MedicationConsumption Create(MedicationConsumption t)
        {
            allMedicationConsumptions.Add(t.MedicineID, t);
            return allMedicationConsumptions[t.MedicineID];
        }

        public bool ExistsById(long id)
        {
            return allMedicationConsumptions.ContainsKey(id);
        }

        public bool Delete(long id)
        {
            return allMedicationConsumptions.Remove(id);
        }
    }

}
