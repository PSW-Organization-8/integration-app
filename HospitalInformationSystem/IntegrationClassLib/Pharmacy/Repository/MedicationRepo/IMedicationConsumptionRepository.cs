using IntegrationClassLib.Pharmacy.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Repository.MedicationRepo
{
    public interface IMedicationConsumptionRepository:IGenericRepository<MedicationConsumption, long>
    {

    }
}
