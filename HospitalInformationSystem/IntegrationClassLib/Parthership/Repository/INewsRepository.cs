using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Model;
using SIMS.Repositories;

namespace IntegrationClassLib.Parthership.Repository
{
    public interface INewsRepository : IGenericRepository<News, long>
    {
    }
}
