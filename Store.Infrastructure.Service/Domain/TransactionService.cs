using RabbitMQ.Domains.Core.Bus;
using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IEventBus _bus;
        public TransactionService(ITransactionRepository transactionRepository, IOrderRepository orderRepository, IEventBus bus, ICardRepository cardRepository)
        {
            _transactionRepository = transactionRepository;
            _orderRepository = orderRepository;
            _bus = bus;
            _cardRepository = cardRepository;
        }

        public async Task<int> AddTransaction(CreateTransactionModel transactionCreate)
        {
            var transaction = transactionCreate.Map();
            var result = await _transactionRepository.CreateAsync(transaction);


            var order = await _orderRepository.GetSingleAsync(x => x.Id == transaction.OrderId);

            if (order == null)
            {
                throw new Exception("შეკვეთა ვერ მოიძებნა");
            }

            order.TransactionId = result;
            _orderRepository.Update(order);

            await _orderRepository.SaveChangesAsync();

            var card = await _cardRepository.GetSingleAsync(x => x.Id == transaction.CardId);
            if (card == null)
            {
                throw new Exception("ბარათი ვერ მოიძებნა");
            }



            _bus.Publish(new CreateTransactionEvent
            {
                Id = result,
                OrderId = transaction.OrderId,
                CustomerId = transaction.CustomerId,
                Amount = transaction.Amount,
                Card = card.MapForTransaction(),
                TransactionDate = transaction.CreateDate,
                Timestamp = DateTime.Now
            });

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
