using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IntegrationClassLib.Tendering.Repository
{
    public class PharmacyOfferRepository : AbstractSqlRepository<PharmacyOffer, long>, IPharmacyOfferRepository
    {
        public PharmacyOfferRepository(MyDbContext context) : base(context)
        {
        }

        protected override long GetId(PharmacyOffer entity)
        {
            return entity.Id;
        }

        public List<PharmacyOffer> GetAllWithComponents()
        {
            return this.context.PharmacyOffers.Include(pharmacyOffer => pharmacyOffer.Components).ToList();
        }
        
    }
}
