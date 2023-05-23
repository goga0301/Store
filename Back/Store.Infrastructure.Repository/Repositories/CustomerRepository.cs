using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<StoreDbContext, Customer, int>, ICustomerRepository
    {
        public CustomerRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
