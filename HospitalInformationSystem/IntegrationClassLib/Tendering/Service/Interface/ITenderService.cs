using System.Collections.Generic;
using IntegrationClassLib.Tendering.Model;

namespace IntegrationClassLib.Tendering.Service.Interface
{
    public interface ITenderService
    {
        List<Tender> GetAll();
        Tender Create(Tender tender);
        Tender CloseTender(long id);
        Tender AcceptOfferAndCloseTender(long tenderId, long pharmacyOfferId);
    }
}
