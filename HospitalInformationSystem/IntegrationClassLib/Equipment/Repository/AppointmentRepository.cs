using IntegrationClassLib.Equipment.Repository.IRepository;
using IntegrationClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Equipment.Repository
{

    class AppointmentRepository : AbstractSqlRepository<Appointment, long>, IAppointmentRepository
    {
        public AppointmentRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Appointment entity)
        {
            return entity.ID;
        }

    }

    
}
