using Banking.Domain.Entities;
using Banking.Domain.Repository.Base;

namespace Banking.Domain.Repository
{
    public interface IAccountRepository : IGenericRepository<Account, int>
    {
    }
}
