using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Repositories
{  
    public class BasicRepository<TEntity> : IBasicRepository<TEntity> where TEntity : class
    {
        private AQLM2Entities context;
        private DbSet<TEntity> dbSet;


        public BasicRepository(AQLM2Entities context)
        {
            context = new AQLM2Entities();
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }       

        public virtual TEntity GetById( object id)
        {
            return dbSet.Find(id);

        }
               

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
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
        public virtual int Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return context.SaveChanges();
        }

        public virtual int Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public virtual int Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return context.SaveChanges();
        }

        public virtual int Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }

        public void save(TEntity t)
        {
          context.SaveChanges();
        }



        public void Dispose()
        {
            if (context != null) context.Dispose();
        }


    }
}
