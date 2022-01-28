using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Repositories
{
    public interface IGenericRepository<T,ID>
    {
        List<T> GetAll();
        T Get(ID id);
        T Update(T t);
        T Create(T t);
        bool ExistsById(ID id);
        bool Delete(ID id);
    }
}
