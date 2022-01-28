using System.Collections.Generic;
using IntegrationClassLib.Tendering.Model;
using Spire.Pdf.Exporting.XPS.Schema;

namespace IntegrationClassLib.Tendering.Service.Interface
{
    public interface IPharmacyOfferService
    {
        List<PharmacyOffer> GetAllPharmacyOffers();
        List<PharmacyOffer> GetAllPharmacyOffersByTenderId(long id);
        PharmacyOffer GetPharmacyOfferById(long id);
    }
}