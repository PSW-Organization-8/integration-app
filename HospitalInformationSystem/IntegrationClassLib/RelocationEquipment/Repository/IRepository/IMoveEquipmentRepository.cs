using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.RelocationEquipment.Repository.IRepository
{
    public interface IMoveEquipmentRepository : IGenericRepository<IntegrationClassLib.SharedModel.MoveEquipment, long>
    {
    }
}
