using Store.Domain.Entities;
using Store.Domain.Repository;
using Store.Infrastructure.Repository.DbContexts;
using Store.Infrastructure.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repository.Repositories
{
    public class TransactionRepository : GenericRepository<StoreDbContext, Transaction>, ITransactionRepository
    {
        public TransactionRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
