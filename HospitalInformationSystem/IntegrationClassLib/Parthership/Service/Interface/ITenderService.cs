using IntegrationClassLib.Parthership.Model.Tendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Service.Interface
{
    public interface ITenderService
    {
        List<Tender> GetAll();
        Tender Create(Tender tender);
        Tender CloseTender(long id);
    }
}
