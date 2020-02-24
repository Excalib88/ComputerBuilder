using System.Linq;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IDbRepository
    {
        //IEnumerable<HardwareItem> GetHardwareItems();
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;

    }
}