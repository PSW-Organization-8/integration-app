using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Tendering.Model;
using SIMS.Repositories;

namespace IntegrationClassLib.Tendering.Repository
{
    public interface IPharmacyOfferRepository : IGenericRepository<PharmacyOffer, long>
    {
        List<PharmacyOffer> GetAllWithComponents();
    }
}
