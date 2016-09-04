using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Linq.Expressions;
using System.Data.Entity;
using Data;
namespace Repositories
{ 
    public class ValOKdIntegrepositories : BasicRepository<ValOKdIntegrtion> ,IBasicRepository<ValOKdIntegrtion> 
    {
        private AQLM2Entities context;
        private DbSet<ValOKdIntegrtion> dbSet;
        public ValOKdIntegrepositories(AQLM2Entities context) : base(context)
        {
            context = new AQLM2Entities();
            this.context = context;  
            dbSet = context.Set<ValOKdIntegrtion>();
        }

        public int Delete(object id)
        {
            ValOKdIntegrtion entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }

        public int Delete(ValOKdIntegrtion entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null) context.Dispose();
        }

        public IQueryable<ValOKdIntegrtion> Get(Expression<Func<ValOKdIntegrtion, bool>> filter = null, Func<IQueryable<ValOKdIntegrtion>, IOrderedQueryable<ValOKdIntegrtion>> orderBy = null, string includeProperties = "")
        {
            IQueryable<ValOKdIntegrtion> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public IQueryable<ValOKdIntegrtion> GetAll()
        {
            return dbSet;
        }

        public ValOKdIntegrtion GetById(object id)
        {
            return dbSet.Find(id);
        }

        public int Insert(ValOKdIntegrtion entity)
        {
            dbSet.Add(entity);
            return context.SaveChanges();
        }

        public void save(ValOKdIntegrtion t)
        {
            context.SaveChanges();
        }

        public int Update(ValOKdIntegrtion entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
