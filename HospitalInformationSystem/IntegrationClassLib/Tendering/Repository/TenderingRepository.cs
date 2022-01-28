using System.Collections.Generic;
using System.Linq;
using IntegrationClassLib.Tendering.Model;
using IntegrationClassLib.Tendering.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IntegrationClassLib.Tendering.Repository
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

        public List<Tender> GetByName(string name)
        {
            return this.context.Tenders.Where(tender => tender.Name.Contains(name)).ToList();
        }

        protected override long GetId(Tender entity)
        {
            return entity.Id;
        }
    }
}
