using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model;

namespace IntegrationClassLib.Parthership.Repository
{
    public class NewsRepository : AbstractSqlRepository<News, long>, INewsRepository
    {
        public NewsRepository(MyDbContext context) : base(context)
        {
        }

        protected override long GetId(News entity)
        {
            return entity.Id;
        }
    }
}
