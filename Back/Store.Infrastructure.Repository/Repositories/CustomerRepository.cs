using Microsoft.Extensions.Caching.Memory;
using Shared.Helpers;
using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class CustomerRepository : CacheRepository<StoreDbContext, Customer, int>, ICustomerRepository
    {
        public CustomerRepository(StoreDbContext context, IMemoryCache cache,ExpirationTimeProvider expirationTimeProvider) : base(context, cache,expirationTimeProvider)
        {
        }
    }
}
