using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
 
namespace Data
{
    public interface IBasicRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        int Delete(TEntity entity);
        int Delete(object id);
        int Update(TEntity entity);
        int Insert(TEntity entity);
        TEntity GetById(object id);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

    }

}
