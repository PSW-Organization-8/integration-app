using System.Collections.Generic;
using IntegrationClassLib.Tendering.Model;
using SIMS.Repositories;

namespace IntegrationClassLib.Tendering.Repository.Interface
{
    public interface IPharmacyOfferRepository : IGenericRepository<PharmacyOffer, long>
    {
        List<PharmacyOffer> GetAllWithComponents();
    }
}
