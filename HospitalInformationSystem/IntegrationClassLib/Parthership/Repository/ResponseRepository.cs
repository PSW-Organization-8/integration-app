using IntegrationClassLib.Parthership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Repository.Interface;

namespace IntegrationClassLib.Parthership.Repository
{
    public class ResponseRepository : AbstractSqlRepository<Response, long>, IResponseRepository
    {

        public ResponseRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(Response entity)
        {
            return entity.Id;
        }
    }
}
