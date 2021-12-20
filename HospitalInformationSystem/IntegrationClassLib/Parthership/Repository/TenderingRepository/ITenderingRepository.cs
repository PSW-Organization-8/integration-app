using IntegrationClassLib.Parthership.Model.Tendering;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Parthership.Repository.TenderingRepository
{
    public interface ITenderingRepository: IGenericRepository<Tender, long>
    {
        List<Tender> GetAllWithMedications();
    }
}
