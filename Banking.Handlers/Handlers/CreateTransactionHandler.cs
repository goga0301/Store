using Banking.Domain.Models.Events;
using Banking.Domain.Models.Mappers;
using Banking.Domain.Service.Domain;
using RabbitMQ.Domains.Core.Bus;

namespace Banking.Handlers.Handlers
{
    public class CreateTransactionHandler : IEventHandler<CreateTransactionEvent>
    {
        private readonly ITransactionService _transactionService;
        private readonly ICardService _cardService;
        private readonly IEventBus _eventBus;
        public CreateTransactionHandler(ITransactionService transactionService, ICardService cardService, IEventBus eventBus)
        {
            _transactionService = transactionService;
            _cardService = cardService;
            _eventBus = eventBus;
        }
        public async Task Handle(CreateTransactionEvent @event)
        {
            var card = await _cardService.getCardByCardNumber(@event.Card.CardNumber);
            if (card == null)
            {
                throw new Exception("ბარათი ვერ მოიძებნა");
            }

            var transaction = @event.Map(card.Id);

            var createdTransactionId = await _transactionService.AddTransaction(transaction);

            _eventBus.Publish(new ProccessTransactionEvent
            {
                Id = createdTransactionId,
                CardId = transaction.CardId,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate

            });


        }
    }
}
