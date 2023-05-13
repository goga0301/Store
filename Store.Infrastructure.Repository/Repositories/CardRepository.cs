using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class CardRepository : GenericRepository<StoreDbContext, Card>, ICardRepository
    {
        public CardRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
