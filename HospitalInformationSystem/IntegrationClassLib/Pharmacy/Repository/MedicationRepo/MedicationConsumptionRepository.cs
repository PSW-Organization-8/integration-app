using IntegrationClassLib.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Repository.MedicationRepo
{
    public class MedicationConsumptionRepository : AbstractSqlRepository<MedicationConsumption, long>, IMedicationConsumptionRepository
    {
        public MedicationConsumptionRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(MedicationConsumption entity)
        {
            return entity.MedicineID;
        }
    }
}
   
    

