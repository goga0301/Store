using Banking.Domain.Models.Mappers;
using Banking.Domain.Models.Models;
using Banking.Domain.Repository;
using Banking.Domain.Service.Domain;

namespace Banking.Infrastructure.Service.Domain
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardRepository _cardRepository;
        public TransactionService(ITransactionRepository transactionRepository,  ICardRepository cardRepository)
        {
            _transactionRepository = transactionRepository;
            _cardRepository = cardRepository;
        }

        public async Task<int> AddTransaction(CreateTransactionModel transactionCreate)
        {
            var transaction = transactionCreate.Map();
            var result = await _transactionRepository.CreateAsync(transaction);

            return result;
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
            transaction.TransactionStatus = transactionUpdate.TransactionStatus;


            _transactionRepository.Update(transaction);
            await _transactionRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<TransactionModel>> GetAllTransactions()
        {
            return (await _transactionRepository.GetAllAsync()).Select(x => x.Map());
        }
    }
}
