using RabbitMQ.Domains.Core.Bus;
using Store.Domain.Models.Domain;
using Store.Domain.Repository;

namespace Store.Admin.Handlers.Handlers
{
    public class TransactionResultHandler : IEventHandler<TransactionResultEvent>
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionResultHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task Handle(TransactionResultEvent @event)
        {
            var transaction = await _transactionRepository.GetSingleAsync(x => x.Id == @event.ExternalId);

            if(transaction == null)
            {
                throw new Exception("ტრანზაქცია ვერ მოიძებნა");
            }

            transaction.Status = @event.TransactionStatus;

            _transactionRepository.Update(transaction);

            await _transactionRepository.SaveChangesAsync();
        }
    }
}
