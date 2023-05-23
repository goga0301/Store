using Banking.Domain.Entities.Enums;
using Banking.Domain.Models.Events;
using Banking.Domain.Repository;
using RabbitMQ.Domains.Core.Bus;

namespace Banking.Handlers.Handlers
{
    public class ProccessTransactionHandler : IEventHandler<ProccessTransactionEvent>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public ProccessTransactionHandler(ITransactionRepository transactionRepository, ICardRepository cardRepository, IAccountRepository accountRepository, IEventBus eventBus)
        {
            _transactionRepository = transactionRepository;
            _cardRepository = cardRepository;
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }

        public async Task Handle(ProccessTransactionEvent @event)
        {

            var transaction = await _transactionRepository.GetSingleAsync(x => x.Id == @event.Id);
            var card = await _cardRepository.GetSingleAsync(x => x.Id == transaction.CardId);
            var account = await _accountRepository.GetSingleAsync(x => x.Id == card.AccountId);
            if (transaction.Amount > account.Balance)
            {
                transaction.TransactionStatus = TransactionStatusEnum.Failed;
                _transactionRepository.Update(transaction);

                await _transactionRepository.SaveChangesAsync();
                _eventBus.Publish(new TransactionResultEvent
                {
                    ExternalId = transaction.ExternalId,
                    TransactionStatus = TransactionStatusEnum.Failed
                });

            }
            else
            {
                account.Balance -= transaction.Amount;
                transaction.TransactionStatus = TransactionStatusEnum.Completed;

                _transactionRepository.Update(transaction);
                _accountRepository.Update(account);

                await _transactionRepository.SaveChangesAsync();
                await _accountRepository.SaveChangesAsync();

                _eventBus.Publish(new TransactionResultEvent
                {
                    ExternalId = transaction.ExternalId,
                    TransactionStatus = TransactionStatusEnum.Completed
                });
            }

        }
    }
}
