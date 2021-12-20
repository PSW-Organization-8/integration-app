using IntegrationClassLib.Parthership.Model.Tendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntegrationClassLib.Parthership.Repository.TenderingRepository
{
    public class TenderingRepository: AbstractSqlRepository<Tender, long>, ITenderingRepository
    {
        public TenderingRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        public List<Tender> GetAllWithMedications()
        {
            return this.context.Tenders.Include(tender => tender.TenderMedications).ToList();
        }

        protected override long GetId(Tender entity)
        {
            return entity.Id;
        }
    }
}
