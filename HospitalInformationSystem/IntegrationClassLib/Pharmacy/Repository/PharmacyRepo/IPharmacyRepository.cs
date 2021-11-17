using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Repository.PharmacyRepo
{
    public interface IPharmacyRepository:IGenericRepository<Pharmacy.Model.Pharmacy, long>
    {
        Pharmacy.Model.Pharmacy GetPharmacyByName(string name);
    }
}
