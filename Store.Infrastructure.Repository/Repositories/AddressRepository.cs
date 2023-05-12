using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class AddressRepository : GenericRepository<StoreDbContext, Address>, IAddressRepository
    {
        public AddressRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
