using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Repository.MedicationRepo
{
    public class MedicationRepository : AbstractSqlRepository<Medication, long>, IMedicationRepository
    {
        public MedicationRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Medication entity)
        {
            return entity.MedicineID;
        }

        public Medication GetMedicationByName(string name)
        {
            var medication = context.Medications.Where(m => m.Name.Equals(name)).FirstOrDefault();
            return medication;
        }
    }
}
