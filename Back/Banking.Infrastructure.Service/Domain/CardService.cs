using Banking.Domain.Models.Mappers;
using Banking.Domain.Models.Models;
using Banking.Domain.Repository;
using Banking.Domain.Service.Domain;

namespace Banking.Infrastructure.Service.Domain
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<int> AddCard(CreateCardModel card)
        {
            return await _cardRepository.CreateAsync(card.Map());
        }

        public async void DeleteCard(int Id)
        {
            var card = await _cardRepository.GetSingleAsync(x => x.Id == Id);
            if (card == null)
            {
                throw new Exception("ბარათი ვერ მოიძებნა");
            }

            _cardRepository.SoftDelete(card);
            await _cardRepository.SaveChangesAsync();
        }



        public async Task<CardModel> GetCardByIdAsync(int id)
        {
            var card = await _cardRepository.GetSingleAsync(x => x.Id == id);
            if (card == null)
            {
                throw new Exception("ბარათი ვერ მოიძებნა");
            }
            return card.Map();
        }

        public async void UpdateCard(UpdateCardModel cardUpdate)
        {
            var card = await _cardRepository.GetSingleAsync(x => x.Id == cardUpdate.Id);
            if (card == null)
            {
                throw new Exception("ბარათი ვერ მოიძებნა");
            }

            card.CardNumber = cardUpdate.CardNumber;
            card.CardholderName = cardUpdate.CardholderName;
            card.CvvCode = cardUpdate.CvvCode;
            card.ExpirationDate = cardUpdate.ExpirationDate;


            _cardRepository.Update(card);
            await _cardRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<CardModel>> GetAllCards()
        {
            return (await _cardRepository.GetAllAsync()).Select(x => x.Map());
        }

        public async Task<CardModel> getCardByCardNumber(string cardNumber)
        {
            var card = await _cardRepository.GetSingleAsync(x => x.CardNumber == cardNumber);
            if (card == null)
            {
                throw new Exception("ბარათი ვერ მოიძებნა");
            }

            return card.Map();

        }
    }
}
