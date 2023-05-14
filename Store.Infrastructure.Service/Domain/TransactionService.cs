using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Service.Domain
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<int> AddTransaction(CreateTransactionModel transaction)
        {
            return await _transactionRepository.CreateAsync(transaction.Map());
        }

        public async void DeleteTransaction(int Id)
        {
            var transaction = await _transactionRepository.GetSingleAsync(x => x.Id == Id);
            if (transaction == null)
            {
                throw new Exception("ტრანზაქცია ვერ მოიძებნა");
            }

            _transactionRepository.SoftDelete(transaction);
            await _transactionRepository.SaveChangesAsync();
        }



        public async Task<TransactionModel> GetTransactionByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetSingleAsync(x => x.Id == id);
            if (transaction == null)
            {
                throw new Exception("ტრანზაქცია ვერ მოიძებნა");
            }
            return transaction.Map();
        }

        public async void UpdateTransaction(UpdateTransactionModel transactionUpdate)
        {
            var transaction = await _transactionRepository.GetSingleAsync(x => x.Id == transactionUpdate.Id);
            if (transaction == null)
            {
                throw new Exception("ტრანზაქცია ვერ მოიძებნა");
            }
            transaction.Status = transactionUpdate.Status;


            _transactionRepository.Update(transaction);
            await _transactionRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<TransactionModel>> GetAllTransactions()
        {
            return (await _transactionRepository.GetAllAsync()).Select(x => x.Map());
        }
    }
}
