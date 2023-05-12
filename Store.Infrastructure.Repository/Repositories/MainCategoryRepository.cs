using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class MainCategoryRepository : GenericRepository<StoreDbContext, MainCategory>, IMainCategoryRepository
    {
        public MainCategoryRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
