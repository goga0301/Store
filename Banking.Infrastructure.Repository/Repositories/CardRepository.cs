using Banking.Domain.Entities;
using Banking.Domain.Repository;
using Banking.Infrastructure.Repository.DbContexts;
using Banking.Infrastructure.Repository.Repositories.Base;

namespace Banking.Infrastructure.Repository.Repositories
{
    public class CardRepository : GenericRepository<BankingDbContext, Card, int>, ICardRepository
    {
        public CardRepository(BankingDbContext context) : base(context)
        {
        }
    }
}
