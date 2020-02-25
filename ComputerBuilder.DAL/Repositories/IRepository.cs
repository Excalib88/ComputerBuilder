using ComputerBuilder.DAL.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IRepository
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity>(int id) where TEntity : class;
        IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

    }
}