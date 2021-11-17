using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Pharmacy.Repository.PharmacyRepo
{
    public class PharmacyRepository : AbstractSqlRepository<Pharmacy.Model.Pharmacy, long>, IPharmacyRepository
    {
        public PharmacyRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        public Model.Pharmacy GetPharmacyByName(string name)
        {
            var pharmacy = context.Pharmacies.Where(p => p.Name.Equals(name)).FirstOrDefault();
            return pharmacy;
        }

        protected override long GetId(Model.Pharmacy entity)
        {
            return entity.Id;
        }
    }
}
