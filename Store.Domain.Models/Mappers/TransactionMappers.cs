using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models.Mappers
{
    public static class TransactionMappers
    {
        public static Transaction Map(this CreateTransactionModel source)
        {
            return new Transaction
            {
                CustomerId = source.CustomerId,
                CardId = source.CardId,
                Amount = source.Amount,
                Status = TransactionStatusEnum.InProgress,
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.UtcNow,
                CreateUserId = "test"
            };
        }
        public static TransactionModel Map(this Transaction source)
        {
            return new TransactionModel
            {
                Id = source.Id,
                OrderId = source.OrderId,
                CustomerId = source.CustomerId,
                CardId = source.CardId,
                Amount = source.Amount,
                Status = source.Status,
                RecordStatus = source.RecordStatus,
                CreateDate = source.CreateDate,
                CreateUserId = source.CreateUserId
            };
        }

    }
}
