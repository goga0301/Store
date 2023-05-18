using Banking.Domain.Models.Models;

namespace Banking.Domain.Service.Domain
{
    public interface ICardService
    {
        Task<int> AddCard(CreateCardModel card);
        void UpdateCard(UpdateCardModel card);
        void DeleteCard(int Id);
        Task<CardModel> GetCardByIdAsync(int Id);
        Task<IEnumerable<CardModel>> GetAllCards();
    }
}
