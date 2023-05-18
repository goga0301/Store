using Banking.Domain.Entities;
using Banking.Domain.Entities.Enums;
using Banking.Domain.Models.Models;

namespace Banking.Domain.Models.Mappers
{
    public static class CardMappers
    {
        public static Card Map(this CreateCardModel source)
        {
            return new Card
            {
                CardNumber = source.CardNumber,
                CardholderName = source.CardholderName,
                ExpirationDate = source.ExpirationDate,
                CvvCode = source.CvvCode,
                AccountId = source.AccountId,
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.Now,
                CreateUserId = "test"
            };

        }

        public static CardModel Map(this Card source)
        {
            return new CardModel
            {
                Id = source.Id,
                CardNumber = source.CardNumber,
                CardholderName = source.CardholderName,
                ExpirationDate = source.ExpirationDate,
                CvvCode = source.CvvCode,
                AccountId = source.AccountId,
                recordStatus = source.RecordStatus,
                CreateDate = source.CreateDate,
                CreateUserId = source.CreateUserId
            };
        }
    }
}
