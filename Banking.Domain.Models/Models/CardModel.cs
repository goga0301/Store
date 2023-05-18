using Banking.Domain.Entities.Enums;

namespace Banking.Domain.Models.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
        public int AccountId { get; set; }  
        public RecordStatusEnum recordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }

    public class CreateCardModel
    {
        public int AccountId { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
    }

    public class UpdateCardModel
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardholderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CvvCode { get; set; }
    }

    public class DeleteCardModel
    {
        public int Id { get; set; }
    }

    
}
