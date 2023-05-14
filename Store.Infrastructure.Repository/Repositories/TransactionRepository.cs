using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;

namespace Store.Infrastructure.Repository.Repositories
{
    public class TransactionRepository : GenericRepository<StoreDbContext, Transaction, int>, ITransactionRepository
    {
        public TransactionRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
