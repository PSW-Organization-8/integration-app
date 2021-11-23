using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib.Equipment.Repository.IRepository
{
    public interface IEquipmentRepository : IGenericRepository<IntegrationClassLib.SharedModel.Equipment, long>
    {
    }
}
