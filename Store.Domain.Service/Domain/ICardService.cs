using Store.Domain.Models.Domain;

namespace Store.Domain.Service.Domain
{
    public interface ICardService
    {
        void AddCard(CreateCardModel card);
        void UpdateCard(UpdateCardModel card);
        void DeleteCard(int Id);
        Task<CardModel> GetCardByIdAsync(int Id);
        Task<IEnumerable<CardModel>> GetAllCards();
    }
}
