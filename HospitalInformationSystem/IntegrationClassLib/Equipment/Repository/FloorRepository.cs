using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using Microsoft.EntityFrameworkCore;
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

        public override List<IntegrationClassLib.SharedModel.Floor> GetAll()
        {
            return context.Floors.Include(x => x.Building).ToList();
        }

    }


}
