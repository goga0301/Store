using System.Linq.Expressions;

namespace Banking.Domain.Repository.Base
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetRowsAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetRowsAsync(int skip, int take, Expression<Func<TEntity, object>> orderByDesc, Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetRowsQueryable(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAllAsync(int skip, int take, Expression<Func<TEntity, object>> orderByDesc, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetAllQueryable(params Expression<Func<TEntity, object>>[] includes);
        Task<bool> AnyAsync(params Expression<Func<TEntity, bool>>[] where);

        Task<TKey> CreateAsync(TEntity entity, bool trackGraph = false);
        Task<IEnumerable<TKey>> CreateRange(IEnumerable<TEntity> entities, bool trackGraph = false);
        void SoftDelete(TEntity entity, bool trackGraph = false);
        void SoftDeleteRange(IEnumerable<TEntity> entities, bool trackGraph = false);
        void Update(TEntity entity, bool trackGraph = false);
        Task SaveChangesAsync();
    }
}
