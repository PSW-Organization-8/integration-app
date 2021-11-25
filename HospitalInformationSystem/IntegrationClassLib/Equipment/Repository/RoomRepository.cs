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
   public  class RoomRepository : AbstractSqlRepository<Room, long>, IRoomRepository
    {
        public RoomRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Room entity)
        {
            return entity.ID;
        }


        public override List<IntegrationClassLib.SharedModel.Room> GetAll()
        {
            return context.Rooms.Include(x => x.Floor).ToList();
        }


    }


}
