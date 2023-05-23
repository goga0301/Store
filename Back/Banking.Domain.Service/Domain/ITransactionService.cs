using Banking.Domain.Models.Models;

namespace Banking.Domain.Service.Domain
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
