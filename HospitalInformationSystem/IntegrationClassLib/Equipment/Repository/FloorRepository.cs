using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Equipment.Repository
{
    public class FloorRepository : AbstractSqlRepository<Floor, long>, IFloorRepository
    {
        public FloorRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Floor entity)
        {
            return entity.ID;
        }

    }


}
