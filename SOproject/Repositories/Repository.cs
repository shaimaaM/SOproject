using Microsoft.EntityFrameworkCore;
using SOproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SOproject.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity Find(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> GetAllQuerable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public Tuple<IQueryable<TEntity>, int> GetAllAsyncPage(int pageNo, int pageSize)
        {
            var data = _context.Set<TEntity>().AsQueryable();
            var total = data.Count();

            if (pageNo != -1)
            {
                data = data.Skip(pageNo * pageSize).Take(pageSize);
            }
            return new Tuple<IQueryable<TEntity>, int>(data, total);
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsQueryable();
        }

      
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

    }
}
