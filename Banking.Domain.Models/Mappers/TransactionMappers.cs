using Banking.Domain.Entities;
using Banking.Domain.Entities.Enums;
using Banking.Domain.Models.Models;

namespace Banking.Domain.Models.Mappers
{
    public static class TransactionMappers
    {
        public static TransactionModel Map(this Transaction entity)
        {
            return new TransactionModel
            {
                Id = entity.Id,
                CardId = entity.CardId,
                Amount = entity.Amount,
                TransactionStatus = entity.TransactionStatus,
                RecordStatus = entity.RecordStatus,
                CreateDate = entity.CreateDate,
                CreateUserId = entity.CreateUserId
            };
        }
        public static Transaction Map(this CreateTransactionModel model)
        {
            return new Transaction
            {
                CardId = model.CardId,
                Amount = model.Amount,
                TransactionStatus = TransactionStatusEnum.Pending,
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.Now,
                CreateUserId = "test"
            };
        }
    }
}
