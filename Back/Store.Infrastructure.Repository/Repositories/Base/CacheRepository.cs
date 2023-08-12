using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Shared.Helpers;
using Store.Domain.Repository.Base;
using Store.Infrastructure.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repository.Repositories.Base
{
    public class CacheRepository<TContext, TEntity, TKey> : IGenericRepository<TEntity, TKey>, IDisposable where TContext : DbContext where TEntity : class where TKey : struct
    {

        private readonly GenericRepository<TContext, TEntity, TKey> _decorated;
        private readonly ExpirationTimeProvider _expirationTimeProvider;
        private readonly IMemoryCache _cache;
        public CacheRepository(TContext context, IMemoryCache cache,ExpirationTimeProvider expirationTimeProvider)
        {
            _decorated = new GenericRepository<TContext,TEntity,TKey>(context);
            _expirationTimeProvider = expirationTimeProvider;
            _cache = cache;
        }

        public Task<bool> AnyAsync(params Expression<Func<TEntity, bool>>[] where)
        {
            return _decorated.AnyAsync(where);
        }

        public Task<TKey> CreateAsync(TEntity entity, bool trackGraph = false)
        {
            return _decorated.CreateAsync(entity, trackGraph);
        }

        public Task<IEnumerable<TKey>> CreateRange(IEnumerable<TEntity> entities, bool trackGraph = false)
        {
            return _decorated.CreateRange(entities, trackGraph);
        }

        public void Dispose()
        {
            _decorated.Dispose();
        }

        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            string key = $"{typeof(TEntity).Name}_GetAllAsync_";
            var incl = includes.Select(x => x.Body.ToString().Split(".")[1]).Aggregate((x, y) => $"{x}_{y}");
            key += incl;
            return await _cache.GetOrCreateAsync(key, async entry =>
            {
                var expirationTime = _expirationTimeProvider.GetExpirationTime(typeof(TEntity).Name, "GetAllAsync");
                entry.SetAbsoluteExpiration(expirationTime);
                return await _decorated.GetAllAsync(includes);
            });
        }

        public Task<List<TEntity>> GetAllAsync(int skip, int take, Expression<Func<TEntity, object>> orderByDesc, params Expression<Func<TEntity, object>>[] includes)
        {
            return _decorated.GetAllAsync(skip, take, orderByDesc, includes);
        }

        public IQueryable<TEntity> GetAllQueryable(params Expression<Func<TEntity, object>>[] includes)
        {
            return _decorated.GetAllQueryable(includes);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return (await GetAllAsync(includes)).SingleOrDefault(where.Compile());
        }

        public Task<List<TEntity>> GetRowsAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return _decorated.GetRowsAsync(where, includes);
        }

        public Task<List<TEntity>> GetRowsAsync(int skip, int take, Expression<Func<TEntity, object>> orderByDesc, Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return _decorated.GetRowsAsync(skip, take, orderByDesc, where, includes);
        }

        public IQueryable<TEntity> GetRowsQueryable(Expression<Func<TEntity, bool>> where)
        {
            return _decorated.GetRowsQueryable(where);
        }

        public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return (await GetAllAsync(includes)).SingleOrDefault(where.Compile());
        }

        public Task SaveChangesAsync()
        {
            return _decorated.SaveChangesAsync();
        }

        public void SoftDelete(TEntity entity, bool trackGraph = false)
        {
            _decorated.SoftDelete(entity, trackGraph);
        }

        public void SoftDeleteRange(IEnumerable<TEntity> entities, bool trackGraph = false)
        {
            _decorated.SoftDeleteRange(entities, trackGraph);
        }

        public void Update(TEntity entity, bool trackGraph = false)
        {
            _decorated.Update(entity, trackGraph);
        }
    }
}
