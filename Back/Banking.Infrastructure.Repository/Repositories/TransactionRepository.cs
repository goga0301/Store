using Banking.Domain.Entities;
using Banking.Domain.Repository;
using Banking.Infrastructure.Repository.DbContexts;
using Banking.Infrastructure.Repository.Repositories.Base;

namespace Banking.Infrastructure.Repository.Repositories
{
    public class TransactionRepository : GenericRepository<BankingDbContext, Transaction, int>, ITransactionRepository
    {
        public TransactionRepository(BankingDbContext context) : base(context)
        {
        }
    }
}
