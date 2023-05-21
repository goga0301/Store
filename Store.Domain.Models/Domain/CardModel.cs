using Store.Domain.Entities.Enums;

namespace Store.Domain.Models.Domain
{
    public class CardModel
    {   
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
        public CardTypeEnum CardType { get; set; }
        public RecordStatusEnum recordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }

    public class CreateCardModel
    {
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
        public CardTypeEnum CardType { get; set; }
    }

    public class UpdateCardModel
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
        public CardTypeEnum CardType { get; set; }
    }

    public class DeleteCardModel
    {
        public int Id { get; set; }
    }

    public class CardModelForTransaction
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
    }
}
