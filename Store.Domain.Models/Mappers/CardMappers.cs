using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Models.Domain;

namespace Store.Domain.Models.Mappers
{
    public static class CardMappers
    {
        public static Card Map(this CreateCardModel source)
        {
            return new Card
            {
                CustomerId = source.CustomerId,
                CardNumber = source.CardNumber,
                CardholderName = source.CardholderName,
                ExpirationDate = source.ExpirationDate,
                CvvCode = source.CvvCode,
                CardType = source.CardType,
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.UtcNow,
                CreateUserId = "test"
            };
        }

        public static CardModel Map(this Card source)
        {
            return new CardModel
            {
                Id = source.Id,
                CustomerId = source.CustomerId,
                CardNumber = source.CardNumber,
                CardholderName = source.CardholderName,
                ExpirationDate = source.ExpirationDate,
                CvvCode = source.CvvCode,
                CardType = source.CardType,
                recordStatus = source.RecordStatus,
                CreateDate = source.CreateDate,
                CreateUserId = source.CreateUserId
            };
        }

        public static CardModelForTransaction MapForTransaction(this Card source)
        {
            return new CardModelForTransaction
            {
                Id = source.Id,
                CardNumber = source.CardNumber,
                CardholderName = source.CardholderName,
                ExpirationDate = source.ExpirationDate,
                CvvCode = source.CvvCode,
                CardType = source.CardType
            };
        }
    }
}
