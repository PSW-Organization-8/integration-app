using IntegrationClassLib.Equipment.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.SharedModel;
using Microsoft.EntityFrameworkCore;

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


        public override List<IntegrationClassLib.SharedModel.Equipment> GetAll()
        {
            return context.Equipments.Include(x => x.Room).ToList();
        }


        public override IntegrationClassLib.SharedModel.Equipment Get(long id) 
        {
            return context.Equipments.Include(x => x.Room).Where(x => x.ID == id).SingleOrDefault();
        }


    }

}
