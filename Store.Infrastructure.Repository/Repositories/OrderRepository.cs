using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class OrderRepository : GenericRepository<StoreDbContext, Order>, IOrderRepository
    {
        public OrderRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
