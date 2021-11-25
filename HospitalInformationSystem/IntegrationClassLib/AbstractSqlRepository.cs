using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClassLib
{
    public abstract class AbstractSqlRepository<Entity, ID>
        where Entity : class
        where ID : IComparable
    {
        protected MyDbContext context;

        private DbSet<Entity> dbSet;

        protected abstract ID GetId(Entity entity);

        public AbstractSqlRepository(MyDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Entity>();
        }

        public List<Entity> GetAll()
        {
            return dbSet.ToList();
        }

        public Entity Get(long id)
        {
            return dbSet.Find(id);
        }

        public bool Delete(Entity entity)
        {
            bool operationValue = false;
            if (ExistsById(GetId(entity)))
            {
                dbSet.Remove(entity);
                context.SaveChanges();
                operationValue = true;
            }
            return operationValue;
        }

        public bool ExistsById(ID id)
        {
            bool exists = true;
            if (dbSet.Find(id) == null)
            {
                exists = false;
            }
            return exists;
        }

        public Entity GetById(ID id)
        {
            return dbSet.Find(id);
        }

        public Entity Update(Entity entity)
        {
            if (ExistsById(GetId(entity)))
            {
                var foundEntity = GetById(GetId(entity));
                context.Entry(foundEntity).CurrentValues.SetValues(entity);
                context.SaveChanges();
                return entity;
            }
            return null;
        }

        public bool Delete(ID id)
        {
            bool retValue = false;
            Entity entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
                retValue = true;
            }
            return retValue;
        }

        public Entity Create(Entity entity)
        {
            if (!ExistsById(GetId(entity)))
            {
                dbSet.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return null;
        }
    }
}
