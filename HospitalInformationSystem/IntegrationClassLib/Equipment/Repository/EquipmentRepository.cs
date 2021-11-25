using IntegrationClassLib.Equipment.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.SharedModel;

namespace IntegrationClassLib.Equipment.Repository
{
    public class EquipmentRepository : AbstractSqlRepository<IntegrationClassLib.SharedModel.Equipment, long>, IEquipmentRepository
    {
        public EquipmentRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(IntegrationClassLib.SharedModel.Equipment entity)
        {
            return entity.ID;
        }

    }

}
