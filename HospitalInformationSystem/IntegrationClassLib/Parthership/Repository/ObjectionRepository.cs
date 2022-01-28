using IntegrationClassLib.Parthership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Repository.Interface;

namespace IntegrationClassLib.Parthership.Repository
{
    public class ObjectionRepository : AbstractSqlRepository<Objection, long>, IObjectionRepository
    {
        public ObjectionRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(Objection entity)
        {
            return entity.Id;
        }
    }
}
