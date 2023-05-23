using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class ProductCategoryRepository : GenericRepository<StoreDbContext, ProductCategory, int>, IProductCategoryRepository
    {
        public ProductCategoryRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
