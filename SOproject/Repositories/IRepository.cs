using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SOproject.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllQuerable();
        TEntity Find(object id);

        Tuple<IQueryable<TEntity>, int> GetAllAsyncPage(int pageNo, int pageSize);

        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<int> AddAsync(TEntity entity);
        public int Add(TEntity entity);

        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
       Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
