using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async void AddCard(CreateCardModel card)
        {
            _cardRepository.Create(card.Map());
            await _cardRepository.SaveChangesAsync();
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
            card.CardType = cardUpdate.CardType;


            _cardRepository.Update(card);
            await _cardRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<CardModel>> GetAllCards()
        {
            return (await _cardRepository.GetAllAsync()).Select(x => x.Map());
        }
    }
}
