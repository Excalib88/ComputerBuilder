using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _dbcontext;

        public Repository(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _dbcontext.Set<TEntity>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            await _dbcontext.Set<TEntity>().AddRangeAsync(entities);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(int id) where TEntity : class
        {
            var entity = await _dbcontext.Set<TEntity>().FindAsync(id);
            _dbcontext.Set<TEntity>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _dbcontext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _dbcontext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _dbcontext.Set<TEntity>().Where(predicate);
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await Task.Run(()=>_dbcontext.Set<TEntity>().Update(entity));
            await _dbcontext.SaveChangesAsync();
        }
    }
}
