using Store.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Service.Domain
{
    public interface ITransactionService
    {
        Task<int> AddTransaction(CreateTransactionModel transaction);
        void UpdateTransaction(UpdateTransactionModel transaction);
        void DeleteTransaction(int Id);
        Task<TransactionModel> GetTransactionByIdAsync(int Id);
        Task<IEnumerable<TransactionModel>> GetAllTransactions();


    }
}
