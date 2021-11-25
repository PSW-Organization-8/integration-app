using IntegrationClassLib.RelocationEquipment.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.RelocationEquipment.Repository
{
    public class MoveEquipmentRepository : AbstractSqlRepository<IntegrationClassLib.SharedModel.MoveEquipment, long>, IMoveEquipmentRepository
    {
        public MoveEquipmentRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(IntegrationClassLib.SharedModel.MoveEquipment entity)
        {
            return entity.ID;
        }

        public override List<IntegrationClassLib.SharedModel.MoveEquipment> GetAll()
        {
            return context.MoveEquipments.Include(x => x.equipment).ToList();
        }

        public override IntegrationClassLib.SharedModel.MoveEquipment Get(long id)
        {
            return context.MoveEquipments.Include(x => x.equipment).Where(x => x.ID == id).SingleOrDefault();
        }

    }
}
