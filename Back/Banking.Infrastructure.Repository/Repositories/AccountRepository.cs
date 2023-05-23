using Banking.Domain.Entities;
using Banking.Domain.Repository;
using Banking.Infrastructure.Repository.DbContexts;
using Banking.Infrastructure.Repository.Repositories.Base;

namespace Banking.Infrastructure.Repository.Repositories
{
    public class AccountRepository : GenericRepository<BankingDbContext, Account, int>, IAccountRepository
    {
        public AccountRepository(BankingDbContext context) : base(context)
        {
        }
    }
}
